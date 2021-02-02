using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Weather.Models
{
    class WeatherHomePageModels : BindableBase
    {
        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                SetProperty(ref _Message, value);
            }
        }

        private string _sDateTime, _sCity, _sCityName, _sUrl, _sTempCel, _sMaxTempCel, _sMinTempCel, _sMaxWindmph, _sHumidity, _sCountry, _sCloud, _spictureBoxIconURL, _windDirection;

         
        private DataTable _dtDataTable;
        public string DateTime
        {
            get
            {
                return _sDateTime;
            }
            set
            {
                SetProperty(ref _sDateTime, value);
            }
        }

        public string City
        {
            get
            {
                return _sCity;
            }
            set
            {
                SetProperty(ref _sCity, value);
            }
        }

        public string CityName
        {
            get
            {
                return _sCityName;
            }
            set
            {
                SetProperty(ref _sCityName, value);
            }
        }

        public string Url
        {
            get
            {
                return _sUrl;
            }
            set
            {
                SetProperty(ref _sUrl, value);
            }
        }

        public string TempCel
        {
            get
            {
                return _sTempCel;
            }
            set
            {
                SetProperty(ref _sTempCel, value);
            }
        }

        public string MaxTempCel
        {
            get
            {
                return _sMaxTempCel;
            }
            set
            {
                SetProperty(ref _sMaxTempCel, value);
            }
        }

        public string MinTempCel
        {
            get
            {
                return _sMinTempCel;
            }
            set
            {
                SetProperty(ref _sMinTempCel, value);
            }
        }

        public string MaxWindmph
        {
            get
            {
                return _sMaxWindmph;
            }
            set
            {
                SetProperty(ref _sMaxWindmph, value);
            }
        }

        public string Humidity
        {
            get
            {
                return _sHumidity;
            }
            set
            {
                SetProperty(ref _sHumidity, value);
            }
        }

        public string Country
        {
            get
            {
                return _sCountry;
            }
            set
            {
                SetProperty(ref _sCountry, value);
            }
        }

        public string Cloud
        {
            get
            {
                return _sCloud;
            }
            set
            {
                SetProperty(ref _sCloud, value);
            }
        }
        public string pictureBoxIconURL
        {
            get
            {
                return _spictureBoxIconURL;
            }
            set
            {
                SetProperty(ref _spictureBoxIconURL, value);
            }
        }

        public string windDirection
        {
            get
            {
                return _windDirection;
            }
            set
            {
                SetProperty(ref _windDirection, value);
            }
        }

        public DataTable dtDataTable
        {
            get
            {
                return _dtDataTable;
            }
            set
            {
                SetProperty(ref _dtDataTable, value);
            }
        }
    }
}
