using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expected_Interfaces;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace Expected_Classes
{
    public class ServiceSunsetCalculator : IServiceSunsetCalculator
    {
        public DateTime GetSunset(DateTime date)
        {
            //This Must Call the service to get data
            //parse the "sunset" from data
            //convert the "sunset" value do DateTime
            
            throw new NotImplementedException();
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
