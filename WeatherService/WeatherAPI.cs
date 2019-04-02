using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;

namespace WeatherService
{
    /// <summary>
    /// Main entry point to interact with the Weather Service API    
    /// </summary>
    public class WeatherAPI
    {
        private readonly HttpClient _httpClient = new HttpClient();

        // allows for mocking of file system access
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Event Handler in order to raise events
        /// </summary>
        public event WeatherEventHandler EventHandler;

        /// <summary>
        /// The basic configuration used for the calls
        /// URL, APIKey, location to save data to and location of Zip codes to test
        /// </summary>
        public Configuration APIConfiguration;

        /// <summary>
        /// List of Zip codes and intervals to allow for flexible calls
        /// </summary>
        public List<ZipInformation> ZipList;

        /// <summary>
        /// List of Timers to be used.
        /// </summary>
        public List<Timer> Timers;


        public WeatherAPI() : this(new FileSystem(), new HttpClient())
        {

        }

        public WeatherAPI(IFileSystem fileSystem, HttpClient httpClient)
        {
            SetupParameters();
            _fileSystem = fileSystem;
            _httpClient = httpClient;
        }

        private void SetupParameters()
        {
            APIConfiguration = new Configuration();
            ZipList = new List<ZipInformation>();
            Timers = new List<System.Timers.Timer>();
        }

        public void FireEvent(string message)
        {
            if (EventHandler == null) return;

            WeatherEvent e1 = new WeatherEvent() { Message = message };
            EventHandler(this, e1);

            e1 = null;
        }

        /// <summary>
        /// Used to setup the list of zip codes and interval times
        /// </summary>
        public void GetAllZipCodes(string fileLocation)
        {
            try
            {
                //TODO:
                // Check if this is a valid file path.
                // Load the file and parse using 
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Used to make a single call to the external API with one zip code and return a CurrentWeather object
        /// </summary>
        /// <param name="zipCode">5 digit code used to look up a city</param>
        /// <returns>CurrentWeather object with the values returned from the Weather service</returns>
        public async Task<CurrentWeather> GetWeatherObjectByZipAsync(string zipCode, string uri)
        {
            try
            {
                var currentWeather = new CurrentWeather() { ZipCode = zipCode };

                var result = await GetWeatherByZipAsync(zipCode, uri);

                currentWeather.ParseJson(result);

                return currentWeather;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Deletes the old log file and creates a new one for use
        /// Allows for an override of the configuration file location
        /// </summary>
        public void ResetSaveFile(string fileLocation)
        {
            try
            {
                if (_fileSystem.File.Exists(fileLocation))
                { _fileSystem.File.Delete(fileLocation); }
                using (_fileSystem.File.Create(fileLocation)) { };
            }
            catch (Exception exp)
            {
                FireEvent("There was a problem with resetting the file: " + exp.Message);
            }
        }

        /// <summary>
        /// Deletes the old log file and creates a new one for use
        /// uses the default from the configuration provided
        /// </summary>
        public void ResetSaveFile()
        {
            ResetSaveFile(APIConfiguration.SaveFileLocation);
        }

        public void StopTimers()
        {
            foreach (var item in Timers)
            {
                item.Enabled = false;
            }
        }

        /// <summary>
        /// Creates a new System.Timers.Timer and adds to the object list
        /// The timer event passes in the parameter for the zipCode
        /// </summary>
        public void CreateMultipleWeatherChecks()
        {
            try
            {
                ResetSaveFile();

                Timers = new List<Timer>();

                foreach (var item in ZipList)
                {
                    System.Timers.Timer timer = new System.Timers.Timer() { Interval = item.Interval, AutoReset = true };
                    timer.Elapsed += (sender, eventArgs) => { TimerHandler(item.ZipCode); };
                    Timers.Add(timer);
                }

                foreach (var item in Timers)
                {
                    item.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                FireEvent("Error while trying to create multiple Timer events." + Environment.NewLine + "Error message: " + exp.Message);
            }

        }

        /// <summary>
        /// Method to be called from the timer to make the weather service calls
        /// </summary>
        /// <param name="zipCode">single zip code</param>
        private void TimerHandler(string zipCode)
        {
            try
            {
                var currentWeather = GetWeatherObjectByZipAsync(zipCode, "").GetAwaiter().GetResult();
                FireEvent("Writing to the file system for zip code " + zipCode);

                // Concerned about using File append because of file locks
                _fileSystem.File.AppendAllText(APIConfiguration.SaveFileLocation, currentWeather.CreateLogLine() + Environment.NewLine);
            }
            catch (Exception exp)
            {
                FireEvent("Error while trying to fire Timer event. Error message: " + exp.Message);
            }
            // it's getting late :D

        }


        /// <summary>
        /// Used to make a single call to the external API with one zip code
        /// </summary>
        public async Task<string> GetWeatherByZipAsync(string zipCode, string uri)
        {
            try
            {
                //TODO: check that the zipCode is valid
                if (zipCode.Length != 5)
                {
                    return "{\"cod\" : 400  \"message\" : Please provide a valid 5 digit zip code}"; ;
                }
                //DEVNOTE: no "using" statement based on: https://ankitvijay.net/2016/09/25/dispose-httpclient-or-have-a-static-instance/

                //Added to allow mocking of URI as well
                if (string.IsNullOrEmpty(uri))
                {
                    uri = APIConfiguration.WeatherServiceFullURI(zipCode);
                }

                var result = _httpClient.GetAsync(new Uri(uri)).Result;

                if (!result.IsSuccessStatusCode)
                {
                    //DEVNOTE: Because of the way that the weather service acts 
                    // even if there is an error the call it will return 200
                    // This is will catch communication problems only
                    return "{\"cod\" :" + result.StatusCode + " \"message\" :" + result.ReasonPhrase + "}";
                }
                else
                {
                    // We passed the most basic of calls, now try to parse
                    return await result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception exp)
            {
                return $"There was an error: {exp.Message}";
            }
        }


    }
}
