using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService;

namespace WeatherService.Tests
{
    [TestFixture]
    public class ConfigurationShould
    {
        [Test]
        public void WeatherServiceFullURI()
        {
            var sut = new WeatherService.Configuration();

            //uses the defaults loaded
            Assert.That(sut.WeatherServiceFullURI("30188"), Is.EqualTo("https://samples.openweathermap.org/data/2.5/weather?zip=30188&appid=be3ab205fe2fe203b55deed662c3021f"));

            sut.APIKey = "ChangedAPISTRING";
            Assert.That(sut.WeatherServiceFullURI("30188"), Is.EqualTo("https://samples.openweathermap.org/data/2.5/weather?zip=30188&appid=ChangedAPISTRING"));
        }

        public void ReturnLoadConfigurationFromFile()
        {

        }

    }
}
