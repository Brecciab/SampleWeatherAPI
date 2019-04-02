using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WeatherService.Tests
{
    [TestFixture]
    public class CurrentWeatherShould
    {
        [Test]
        public void SetWindDirection()
        {
            var sut = new CurrentWeather();

            Assert.That(sut.ParseWindDirection("300"), Is.EqualTo("North Westerly"));
        }

        [Test]
        public void ParseJson()
        {
            var sut = new CurrentWeather();

            sut.ParseJson("{\"main\": {\"temp\": \"280.44\"}}");
            // Just testing a few values
            Assert.That(sut.Temperature, Is.EqualTo("45.122"));
        }

        [Test]
        public void CreateLogLine()
        {
            var sut = new CurrentWeather();
            sut.ParseJson("{\"main\": {\"temp\": \"180.5\"}}");

            var result = sut.CreateLogLine();

            // There is the problem of the time in the line
            Assert.That(result.Length, Is.GreaterThan(5));
        }

        [Test]
        public void ConvertTemperature()
        {
            var sut = new CurrentWeather();

            var result = sut.ConvertTemperature("280.44");

            Assert.That(result, Is.EqualTo("45.122"));
        }
    }
}
