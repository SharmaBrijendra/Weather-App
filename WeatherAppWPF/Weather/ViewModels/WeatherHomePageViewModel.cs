#region
//Author: Brijendra Sharma
//Date of Creation - Feb. 01 2021
// Date of last Modification - Feb. 01 2021
//Reason: Initial version of Code

#endregion

using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Weather.Models;

namespace Weather.ViewModels
{
    class WeatherHomePageViewModel : BindableBase
    {
        private WeatherHomePageModels weatherHomePageModels;

        DataTable dt = null;

        /// <summary>
        /// initializing the variable in the constructor
        /// </summary>
        public WeatherHomePageViewModel()
        {
            weatherHomePageModels = new WeatherHomePageModels();

            ShowWeatherCommand = new DelegateCommand(ShowTemperatureMethod);

            AddToFavroiteCommand = new DelegateCommand(AddToFavroiteMethod);

            FInitializeDataTable();            

            OnLoadWeatherAppCurrentLocation("London, On");  

        }

        /// <summary>
        /// This method populates data on the screen on start up / first loading of the page
        /// </summary>
        /// <param name="currentLocation"></param>
        private void OnLoadWeatherAppCurrentLocation(string currentLocation)
        {
            weatherHomePageModels.City = currentLocation;

            weatherHomePageModels.Url = string.Format("https://api.weatherapi.com/v1/forecast.xml?key={0}&q={1}&days=1", Properties.Resources.csKeyForAPI, weatherHomePageModels.City);
            
            XDocument doc = XDocument.Load(weatherHomePageModels.Url);

            weatherHomePageModels.DateTime = (string)doc.Descendants("localtime").FirstOrDefault();

            weatherHomePageModels.DateTime = weatherHomePageModels.DateTime.Remove(10);

            weatherHomePageModels.CityName = (string)doc.Descendants("name").FirstOrDefault();

            weatherHomePageModels.Country = (string)doc.Descendants("country").FirstOrDefault();

            weatherHomePageModels.TempCel = (string)doc.Descendants("temp_c").FirstOrDefault() + "\u00B0" + "C";

            weatherHomePageModels.MaxTempCel = (string)doc.Descendants("maxtemp_c").FirstOrDefault() + "\u00B0" + "C";

            weatherHomePageModels.MinTempCel = (string)doc.Descendants("mintemp_c").FirstOrDefault() + "\u00B0" + "C";

            weatherHomePageModels.MaxWindmph = (string)doc.Descendants("maxwind_mph").FirstOrDefault();

            weatherHomePageModels.Humidity = (string)doc.Descendants("avghumidity").FirstOrDefault();

            weatherHomePageModels.Cloud = (string)doc.Descendants("text").FirstOrDefault();

            weatherHomePageModels.windDirection = (string)doc.Descendants("wind_dir").FirstOrDefault();

        }

        /// <summary>
        /// initializing the DataTable with Columns name
        /// </summary>
        private void FInitializeDataTable()
        {
            dt = new DataTable();

            dt.Columns.Add("City", typeof(string));

            dt.Columns.Add("Country", typeof(string));

            dt.Columns.Add("Date", typeof(string));

            dt.Columns.Add("Max Temp", typeof(string));

            dt.Columns.Add("Min Temp", typeof(string));

            dt.Columns.Add("Cloud", typeof(string));
        }

        /// <summary>
        /// This is responsible for adding and populating data in the Data Table.
        /// </summary>
        public void AddToFavroiteMethod()
        {
            try
            {
                if (weatherHomePageModels.City == null)
                {
                    MessageBox.Show("Please enter city name", "Alert", MessageBoxButton.OK);
                    return;
                }

                // Secret API key is hidden under  Resx file under Properties/Resources.Resx
                weatherHomePageModels.Url = string.Format("https://api.weatherapi.com/v1/forecast.xml?key={0}&q={1}&days=1", Properties.Resources.csKeyForAPI, weatherHomePageModels.City);

                // parsing XML data after sending API call
                XDocument doc = XDocument.Load(weatherHomePageModels.Url);

                // looping for displaying data in the data table
                foreach (var temp in doc.Descendants("forecastday"))
                {

                    dt.Rows.Add(new object[]{
                    (string)doc.Descendants("name").FirstOrDefault(),
                    (string)doc.Descendants("country").FirstOrDefault(),
                    (string)doc.Descendants("date").FirstOrDefault(),
                    (string)doc.Descendants("maxtemp_c").FirstOrDefault(),
                    (string)doc.Descendants("mintemp_c").FirstOrDefault(),
                    (string)doc.Descendants("text").FirstOrDefault(),

                });
                }
                
                weatherHomePageModels.dtDataTable = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application encounter a problem and trying to close the application", "Error", MessageBoxButton.OK);
                Application.Current.Shutdown();
                return;

            }

        }

        /// <summary>
        /// This method is responsible for displaying weather report on home page
        /// </summary>
        private void ShowTemperatureMethod()
        {
            try
            {
                
                if (weatherHomePageModels.City == null)
                {
                    MessageBox.Show("Please enter city name", "Alert", MessageBoxButton.OK);
                    weatherHomePageModels.City = string.Empty;
                    return;
                }

                weatherHomePageModels.Url = string.Format("https://api.weatherapi.com/v1/forecast.xml?key={0}&q={1}&days=1", Properties.Resources.csKeyForAPI, weatherHomePageModels.City);

                XDocument doc = XDocument.Load(weatherHomePageModels.Url);

                weatherHomePageModels.DateTime = (string)doc.Descendants("localtime").FirstOrDefault();

                weatherHomePageModels.DateTime = weatherHomePageModels.DateTime.Remove(10);

                weatherHomePageModels.CityName = (string)doc.Descendants("name").FirstOrDefault();

                weatherHomePageModels.Country = (string)doc.Descendants("country").FirstOrDefault();

                weatherHomePageModels.TempCel = (string)doc.Descendants("temp_c").FirstOrDefault() + "\u00B0" + "C";

                weatherHomePageModels.MaxTempCel = (string)doc.Descendants("maxtemp_c").FirstOrDefault() + "\u00B0" + "C";

                weatherHomePageModels.MinTempCel = (string)doc.Descendants("mintemp_c").FirstOrDefault() + "\u00B0" + "C";

                weatherHomePageModels.MaxWindmph = (string)doc.Descendants("maxwind_mph").FirstOrDefault();

                weatherHomePageModels.Humidity = (string)doc.Descendants("avghumidity").FirstOrDefault();

                weatherHomePageModels.Cloud = (string)doc.Descendants("text").FirstOrDefault();

                weatherHomePageModels.windDirection = (string)doc.Descendants("wind_dir").FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("City Not Found" + "\n Please try again", "Error", MessageBoxButton.OK);
                //Application.Exit();
            }
        }

        /// <summary>
        /// setting property for AddToFavroiteCommand command of XMAL to bind with method in cs file to hit click event of the button
        /// </summary>
        public ICommand AddToFavroiteCommand
        {
            get;
            private set;
        }


        /// <summary>
        /// setting property for ShowWeatherCommand command of XMAL to bind with method in cs file to hit click event of the button
        /// </summary>
        public ICommand ShowWeatherCommand
        {
            get;
            private set;
        }


        /// <summary>
        /// Setting property for model class variable to work on view model
        /// </summary>
        public WeatherHomePageModels WeatherHomePageModels
        {
            get
            {
                return weatherHomePageModels;
            }
            set
            {
                SetProperty(ref weatherHomePageModels, value);
            }
        }

    }
}
