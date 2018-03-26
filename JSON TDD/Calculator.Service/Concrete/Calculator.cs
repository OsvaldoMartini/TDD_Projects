using System;
using Calculator.Service.Interfaces;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace Calculator.Service.Concrete
{
    public class Calculator : ICalculator
    {
        private IGetServices _service;
        public IGetServices Service
        {
            get
            {
                if (_service == null)
                    _service = new GetServices();
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


        public static int ParseTotalMovies(string jsonContent)
        {
            //Pick things in RunTime
            //"Dynamic" -> We are going to be able to pick up thinks in Run-Time rather then compiler-time
            try
            {
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                int totalMovies;
                Int32.TryParse(data.total.ToString(),out totalMovies);
                return totalMovies;
         
            }
            catch (RuntimeBinderException)
            {
                //"$" JSON Interpolation in this VS-2013 "$JSON object does not contain 'sunset': {jsonContent}"); Does not Worked
                throw new ArgumentException(string.Format("JSON object does not contain 'total': {0}", jsonContent));
            }
        }


        public static DateTime ToLocalTime(string timeString, DateTime date)
        {
            DateTime time = DateTime.Parse(timeString);
            return date.Date + time.TimeOfDay;
        }

        public int GetMoviesTotal(string subStr)
        {
            //This Must Call the service to get data
            //HackerRank Rest Services Service Data
            //string dataHackerHank = "{\"page\":1,\"per_page\":10,\"total\":2770,\"total_pages\":277,\"data\":[{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BYzE4NTRmMDYtNWYzYi00YmNkLTk4NDEtYjFmMDc4ODQ3ODY2XkEyXkFqcGdeQXVyNTUyMzE4Mzg@._V1_SX300.jpg\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt0114898\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1995,\"imdbID\":\"tt0189200\"},{\"Poster\":\"N/A\",\"Title\":\"The Making of 'Waterworld'\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt2670548\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld 4: History of the Islands\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0161077\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1997,\"imdbID\":\"tt0455840\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0390617\"},{\"Poster\":\"N/A\",\"Title\":\"Swordquest: Waterworld\",\"Type\":\"game\",\"Year\":1983,\"imdbID\":\"tt2761086\"},{\"Poster\":\"N/A\",\"Title\":\"Behind the Scenes of the Most Fascinating Waterworld on Earth: The Great Backwaters, Kerala.\",\"Type\":\"movie\",\"Year\":2014,\"imdbID\":\"tt5847056\"},{\"Poster\":\"N/A\",\"Title\":\"Louise's Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0298417\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":2001,\"imdbID\":\"tt0381702\"}]}"; 

            /*Refactored to Get From Real Service*/
            // xxx call the Service to get Data
            //var service = new SolarCalculator();
            string serviceData = Service.GetServiceQtdMovies(subStr);

            //parse the "sunset" from data
            int moviesTotal = ParseTotalMovies(serviceData);

            
            return moviesTotal;
        }


    }
}
