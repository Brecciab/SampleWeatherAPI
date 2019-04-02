using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public class Configuration
    {
        /// <summary>
        /// Location of the WeatherAPIURI
        /// </summary>
        public string WeatherAPIURI { get; set; }

        /// <summary>
        /// String required as part of the calls to the WeatherAPI
        /// </summary>
        public string APIKey { get; set; }

        /// <summary>
        /// File location for the data to be saved
        /// </summary>
        public string SaveFileLocation { get; set; }

        /// <summary>
        /// Location where the city and zip combination is stored
        /// </summary>
        public string ZipInformationLocation { get; set; }

        public Configuration()
        {
            //Hard coded defaults 
            WeatherAPIURI = @"https://samples.openweathermap.org/data/2.5/weather?zip=<zipcode>&appid=<apikey>";
            APIKey = "be3ab205fe2fe203b55deed662c3021f";
            // In production you would never use this
            SaveFileLocation = AppDomain.CurrentDomain.BaseDirectory + $"WeatherTestData_{DateTime.UtcNow.ToString("MMddyyyy")}.txt";
            ZipInformationLocation = AppDomain.CurrentDomain.BaseDirectory + $"ZipCodes.json";
        }

        /// <summary>
        /// Combines the values to provided with other configuration settings to get a call address.
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public string WeatherServiceFullURI(string zipcode)
        {
            return WeatherAPIURI.Replace("<zipcode>", zipcode).Replace("<apikey>", APIKey);
        }

        //Assumes that the file is JSON and has all the correct object names
        public string LoadConfigurationFromFile(string fileLocation)
        {
            try
            {
                //TODO: Verify that the file is valid
                if (true)
                {
                    // If valid then try to load the new settings from it

                    // Normally I would not overwrite the empty strings but probably not required for this sample

                    return "Load completed";
                }
                else
                {
                    return "Either the file is an invalid type, unable to locate or read. Please check the file path and try again.";
                }


            }
            catch (Exception exp)
            {

                return $"There was an error: {exp.Message}";
            }
        }
    }
}
