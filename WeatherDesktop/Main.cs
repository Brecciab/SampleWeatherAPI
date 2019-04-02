using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherService;

namespace WeatherDesktop
{
    public partial class Main : Form
    {

        WeatherAPI _weather = new WeatherAPI();

        public Main()
        {
            InitializeComponent();

            //Set the values on form
            WeatherServiceURLInput.Text = _weather.APIConfiguration.WeatherAPIURI;
            APIKeyInput.Text = _weather.APIConfiguration.APIKey;
            SaveFileLocationInput.Text = _weather.APIConfiguration.SaveFileLocation;
            ZipCodeInput.Text = _weather.APIConfiguration.ZipInformationLocation;
            ZipInformationLocationInput.Text = _weather.APIConfiguration.ZipInformationLocation;

            //Default zip code
            ZipCodeInput.Text = "30188";

            WireEventHandlers(_weather);
        }

        private void Test1_ClickAsync(object sender, EventArgs e)
        {
            MakeBasicWebCall(ZipCodeInput.Text);                      
        }

        public void MakeBasicWebCall(string zipCode)
        {
            ResultsDisplay.Text = $"Making a simple call to weather based on zip{Environment.NewLine}";

            CurrentWeather now = _weather.GetWeatherObjectByZipAsync(zipCode, "").GetAwaiter().GetResult();
            if (now.Cod == "200")
            {
                ResultsDisplay.AppendText($"Result set successful {Environment.NewLine}");
                ResultsDisplay.AppendText($"Retrieval Time:  {now.RetrievalTime.ToLongDateString()}{Environment.NewLine}");
                ResultsDisplay.AppendText($"Condition:  {now.Condition}{Environment.NewLine}");
                ResultsDisplay.AppendText($"Pressure:  {now.Pressure}{Environment.NewLine}");
                ResultsDisplay.AppendText($"WindDirection:  {now.WindDirection}{Environment.NewLine}");
                ResultsDisplay.AppendText($"WindSpeed:  {now.WindSpeed}{Environment.NewLine}");
                ResultsDisplay.AppendText($"Humidity:  {now.Humidity}%{Environment.NewLine}");
                ResultsDisplay.AppendText(now.CreateLogLine() + Environment.NewLine);
            }
            else
            {
                ResultsDisplay.AppendText($"There was an error attempting to connect to the service: {Environment.NewLine} Code: {now.Cod}{Environment.NewLine}Message: {now.Message}{now.ErrorMessage}");
            }
        }


        /// <summary>
        /// This will load the configuration from the TextBoxes
        /// </summary>
        private void UpdateConfiguration_Click(object sender, EventArgs e)
        {
            ResultsDisplay.AppendText(Environment.NewLine + "Updating configuration Information." + Environment.NewLine);
            if (!string.IsNullOrEmpty(WeatherServiceURLInput.Text))
            { _weather.APIConfiguration.WeatherAPIURI = WeatherServiceURLInput.Text; }
            if (!string.IsNullOrEmpty(APIKeyInput.Text))
            { _weather.APIConfiguration.APIKey = APIKeyInput.Text; }
            if (!string.IsNullOrEmpty(SaveFileLocationInput.Text))
            { _weather.APIConfiguration.SaveFileLocation = SaveFileLocationInput.Text; }
            if (!string.IsNullOrEmpty(ZipCodeInput.Text))
            { _weather.APIConfiguration.ZipInformationLocation = ZipCodeInput.Text; }
        }

        private void StartMultipleTimers_Click(object sender, EventArgs e)
        {
            _weather.ZipList.Add(new ZipInformation { ZipCode = "30188", Interval = 6000});
            _weather.ZipList.Add(new ZipInformation { ZipCode = "32184", Interval = 7000 });
            _weather.ZipList.Add(new ZipInformation { ZipCode = "10001", Interval = 15000 });

            _weather.CreateMultipleWeatherChecks();
            ResultsDisplay.Text = "The weather checks have been created." + Environment.NewLine; ;
        }

        private void WireEventHandlers(WeatherAPI weather)
        {
            WeatherEventHandler handler = new WeatherEventHandler(OnHandler1);
            weather.EventHandler += handler;
        }

        private void OnHandler1(object sender, WeatherEvent e)
        {
            if (InvokeRequired)
            {
                ResultsDisplay.Invoke((MethodInvoker)delegate { ResultsDisplay.Text += e.Message + Environment.NewLine; });                
            }
        }

        private void StopMultipleTimers_Click(object sender, EventArgs e)
        {
            ResultsDisplay.AppendText(Environment.NewLine + "Stopping Timers");
            _weather.StopTimers();
        }
    }
}
