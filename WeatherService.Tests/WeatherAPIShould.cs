using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherService.Tests
{
    [TestFixture]
    public class WeatherAPIShould
    {
        [Test]
        public void ZipList_AddNewValues()
        {
            var sut = new WeatherAPI();

            sut.ZipList.Add(new ZipInformation { ZipCode = "30004", Interval = 6000 });

            Assert.That(sut.ZipList, Has.Exactly(1).Matches<ZipInformation>(item => item.ZipCode == "30004" && item.Interval == 6000));
            Assert.That(sut.ZipList, Has.Exactly(0).Matches<ZipInformation>(item => item.ZipCode == "30188" && item.Interval == 6000));
        }



        [Test]
        public void SetupParameters_emptyList()
        {
            var sut = new WeatherAPI();

            Assert.That(sut.ZipList.Count, Is.EqualTo(0));
            Assert.That(sut.Timers.Count, Is.EqualTo(0));
        }

        [Test]
        public void ResetSaveFile_newFileCreated()
        {
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("test1\test2\test3");
            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var sut = new WeatherAPI(mockFileSystem, null);

            sut.ResetSaveFile(@"C:\temp\in.txt");

            MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\in.txt");

            string[] outputLines = mockOutputFile.TextContents.SplitLines();

            Assert.That(outputLines.Count, Is.EqualTo(0));
        }

        [Test]
        public void StopTimers_timersDisabled()
        {
            var sut = new WeatherAPI();

            //TODO: I know there is a mock for this but can't find it right now... grrr.
            sut.Timers.Add(new System.Timers.Timer() { Interval = 600000, Enabled = true });

            sut.StopTimers();

            Assert.That(sut.Timers, Has.One.Matches<System.Timers.Timer>(item => item.Enabled == false));

        }

        [Test]
        public void CreateMultipleWeatherChecks_NumberOfTimersAdded()
        {
            var sut = new WeatherAPI();

            sut.ZipList.Add(new ZipInformation() { ZipCode = "30004", Interval = 60000 });

            sut.CreateMultipleWeatherChecks();

            Assert.That(sut.Timers, Has.One.Matches<System.Timers.Timer>(item => item.Enabled == true));
            Assert.That(sut.ZipList.Count, Is.EqualTo(1));

            //TODO: Really wish I had time to find this but google foo is failing me right now
            sut.StopTimers();

        }

        [Test]
        [TestCase("{\"main\": {\"temp\": \"280.44\"}}", "45.122" )]
        public void GetWeatherObjectByZipAsync_mockedCall(string fakeJSON, string fakeTemperature)
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<System.Threading.CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = System.Net.HttpStatusCode.OK,
                   Content = new StringContent(fakeJSON),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            var sut = new WeatherAPI(null, httpClient);

            //ACT
            var currentWeather = sut.GetWeatherObjectByZipAsync("30004", "http://test.it.com/");

            //ASSERT
            Assert.That(currentWeather, Is.Not.Null);
            Assert.That(currentWeather.Result.Temperature, Is.EqualTo(fakeTemperature));

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("http://test.com/");

            handlerMock.Protected().Verify("SendAsync",Times.Exactly(0), 
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get 
                  && req.RequestUri == expectedUri // to this uri
                  ), ItExpr.IsAny<System.Threading.CancellationToken>());
        }

        [Test]
        [TestCaseSource("TestCurrentWeather")]
        public void SaveCurrentWeatherValues(CurrentWeather currentWeather )
        {
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("test1\test2\test3");
            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var sut = new WeatherAPI(mockFileSystem, null);
            sut.APIConfiguration.SaveFileLocation = @"C:\temp\in.txt";
            sut.ResetSaveFile(@"C:\temp\in.txt");

            var result = sut.SaveCurrentWeatherValues(currentWeather);

            MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\in.txt");

            string[] outputLines = mockOutputFile.TextContents.SplitLines();

            Assert.That(result, Is.EqualTo(true));
            Assert.That(outputLines.Count, Is.EqualTo(1));
            Assert.That(outputLines[0].ToString(), Is.EqualTo(currentWeather.CreateLogLine()));


            
        }

        static object[] TestCurrentWeather =
        {
            new CurrentWeather() { Message = "Testing the writing", Cod = "404" },
            new CurrentWeather() { Message = "Testing the writing", Cod = "200" },
            new CurrentWeather() { Message = "Testing the writing", Cod = "503" },
        };

        static object[] TestFakeJSON =
        {
            "{'main': {'temp': '280.44'}}",
            "{'main': {'temp': '380.44'}}",
            "{'main': {'temp': '480.44'}}",
        };
    }
}
