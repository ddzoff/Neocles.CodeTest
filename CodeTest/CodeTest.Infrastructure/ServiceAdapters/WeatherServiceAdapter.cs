using CodeTest.Application.Contracts.ServiceAdapters;
using CodeTest.Application.Models;
using CodeTest.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Infrastructure.Services
{
    public class WeatherServiceAdapter : IWeatherServiceAdapter
    {
        private readonly OpenWeatherMapSettings _settings;

        public WeatherServiceAdapter(OpenWeatherMapSettings settings)
        {
            _settings = settings;
        }

        public async Task<string> GetPolutionData(decimal latitude, decimal longitude, DateTime date)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_settings.OpenWeatherApiBaseUrl);
            var response = await httpClient.GetAsync(String.Format(_settings.OpenWeatherApiPolutionPath, 
                latitude.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), 
                longitude.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), $"{date.ToString("s")}Z", _settings.OpenWeatherApiKey));            
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Open weather map API get polution request failed, status code: {response.StatusCode}");

            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
