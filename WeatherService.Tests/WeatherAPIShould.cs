using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;

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
        public void GetWeatherObjectByZipAsync()
        {
            var sut = new WeatherAPI();

            //TODO: 
            Assert.That(sut.ZipList.Count, Is.EqualTo(0));
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

            var sut = new WeatherAPI(mockFileSystem);

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
    }
}
