using System;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using SunsetCalculator_Library.Interfaces;

namespace SunsetCalculator_Library.Concrete
{
    public class ServiceSunsetCalculator : IServiceSunsetCalculator
    {
        private ISolarCalculator _service;
        public ISolarCalculator Service
        {
            get
            {
                if (_service == null)
                    _service = new SolarCalculator();
                return _service;
            }
            set { _service = value; }
        }

        public DateTime GetSunset(DateTime date)
        {
            //This Must Call the service to get data
            //HardCode Service Data
            //string serviceData = "{\"result\":{\"sunrise\":\"6:37:49 AM\",\"sunset\":\"4:42:49 PM\",\"solar_noon\":\"11:40:19 AM\",\"day_length\":\"10:05:00.1530000\"},\"status\":\"OK\"}";

            /*Refactored to Get From Real Service*/
            // xxx call the Service to get Data
            //var service = new SolarCalculator();
            string serviceData = Service.GetServiceDate(date);

            //parse the "sunset" from data
            string sunsetData = ParseSunset(serviceData);
            
            //convert the "sunset" value do DateTime
            DateTime sunset = ToLocalTime(sunsetData, date);

            return sunset;
        }

        public DateTime GetSunrise(DateTime date)
        {
            //This Must Call the service to get data
            //parse the "sunrise" from data
            //convert the "sunrise" value do DateTime
            
            throw new NotImplementedException();
        }

        public static string ParseSunset(string jsonContent)
        {
            //Pick things in RunTime
            //"Dynamic" -> We are going to be able to pick up thinks in Run-Time rather then compiler-time
            try
            {
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                string sunset = data.result.sunset;
                return sunset;

            }
            catch (RuntimeBinderException)
            {
                //"$" JSON Interpolation in this VS-2013 "$JSON object does not contain 'sunset': {jsonContent}"); Does not Worked
                throw new ArgumentException(string.Format("JSON object does not contain 'sunset': {0}", jsonContent));
            }
        }

        public static DateTime ToLocalTime(string timeString, DateTime date)
        {
            DateTime time = DateTime.Parse(timeString);
            return date.Date + time.TimeOfDay;
        }

    }
}
