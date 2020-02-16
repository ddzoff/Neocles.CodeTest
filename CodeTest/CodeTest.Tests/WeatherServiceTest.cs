using System;
using System.Linq;
using System.Threading.Tasks;
using CodeTest.Application.Contracts.ServiceAdapters;
using CodeTest.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeTest.Tests
{
    [TestClass]
    public class WeatherServiceTest
    {
        private Mock<IWeatherServiceAdapter> _weatherServiceAdapter;

        public WeatherServiceTest()
        {
            _weatherServiceAdapter = new Mock<IWeatherServiceAdapter>();
        }

        [TestMethod]
        public async Task GetPolutionData_Test()
        {
            // Setup
            string jsonPolution = "{ 'time': '2016-03-03T12:00:00Z', 'location': { 'latitude': 0.0, 'longitude': 10.0 }, 'data': [ { 'precision': -4.999999987376214e-7, 'pressure': 1000, 'value': 8.168363052618588e-8 }] }";

            string latitude = "10";
            string longitude = "0";
            string timestamp = "2016-11-23T01:04:00";

            _weatherServiceAdapter
                .Setup(x => x.GetPolutionData(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<DateTime>()))
                .ReturnsAsync(jsonPolution);

            //Run
            WeatherService weatherService = new WeatherService(_weatherServiceAdapter.Object);
            var polutionData = await weatherService.GetWeatherPolution(latitude, longitude, timestamp);

            // Test            
            Assert.AreEqual(DateTime.Parse("2016-03-03T12:00:00Z").ToUniversalTime(), polutionData.MeasureDate);
            Assert.AreEqual(Decimal.Parse("0,0"), polutionData.Location.Latitude);
            Assert.AreEqual(Decimal.Parse("10,0"), polutionData.Location.Longitude);
            Assert.AreEqual(1, polutionData.PolutionDetails.Count);
            Assert.AreEqual(Double.Parse("-4,999999987376214e-7"), polutionData.PolutionDetails.First().Precision);
            Assert.AreEqual(Double.Parse("1000"), polutionData.PolutionDetails.First().Pressure);
            Assert.AreEqual(Double.Parse("8,168363052618588e-8"), polutionData.PolutionDetails.First().Value);
        }
    }
}
