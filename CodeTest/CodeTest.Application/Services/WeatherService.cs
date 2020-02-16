using CodeTest.Application.Contracts.ServiceAdapters;
using CodeTest.Application.Models;
using CodeTest.Application.Services.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Application.Services
{
    public class WeatherService : IWeatherService
    {
        public readonly IWeatherServiceAdapter _weatherServiceAdapter;

        public WeatherService(IWeatherServiceAdapter weatherServiceAdapter)
        {
            _weatherServiceAdapter = weatherServiceAdapter;
        }

        public async Task<Polution> GetWeatherPolution(string latitude, string longitude, string timestamp)
        {
            if (!decimal.TryParse(longitude, out var parsedLongitude) || parsedLongitude < -180 || parsedLongitude > 180)
            {
                throw new ArgumentException("Argument has wrong format", longitude);
            }

            if (!decimal.TryParse(latitude, out var parsedLatitude) || parsedLatitude < -90 || parsedLatitude > 90)
            {
                throw new ArgumentException("Argument has wrong format", latitude);
            }

            if (!DateTime.TryParse(timestamp, out var date))
            {
                throw new ArgumentException("Invalid format. Should be: yyyy-MM-ddThh:mm:ss", timestamp);
            }

            var responseBody = await _weatherServiceAdapter.GetPolutionData(parsedLatitude, parsedLongitude, date);

            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyyMMddTHHmmssZ" });
            return JsonConvert.DeserializeObject<Polution>(responseBody, serializeSettings);
        }
    }
}
