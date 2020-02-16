using CodeTest.Application.Models;
using CodeTest.Application.Services.Abstract;
using CodeTest.Models;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeTest.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;
               
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get polution data
        /// </summary>
        /// <returns>Polution data for given location and date</returns>
        /// <response code="200">Polution data retrieved from openweathermap api.</response>
        /// <response code="400">Arguments in wrong format</response>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string longitude, string latitude, string timestamp)
        {
            var polutionData = await _weatherService.GetWeatherPolution(longitude, latitude, timestamp);

            var apiResponse = new ApiResponseEnvelope<Polution>()
            {
                Data = polutionData
            };

            return Ok(apiResponse);
        }   
    }
}
