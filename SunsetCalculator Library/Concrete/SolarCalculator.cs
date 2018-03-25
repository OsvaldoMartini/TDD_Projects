using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Schema;
using SunsetCalculator_Library.Interfaces;

namespace SunsetCalculator_Library.Concrete
{
    public class SolarCalculator : ISolarCalculator
    {
        private ISolarCalculator _solarCalculatorImplementation;

        public string GetServiceDate(DateTime date)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1200/api/SolarCalculator");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var apiString = string.Format("?lat=33.6624&lng=-117.7470&date={0:yyyy-MM-dd}", date);
                HttpResponseMessage response = client.GetAsync(apiString).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
            }

            return null;

        }

        public string GetServiceQtdMovies(string value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonmock.hackerrank.com/api/movies/search/");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var apiString = string.Format("?Title={0}", value);
                HttpResponseMessage response = client.GetAsync(apiString).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
            }

            return string.Empty;

        }
    }

    public class ResponseObj
    {
        public string total;
        public string total_pages;
    }
}
