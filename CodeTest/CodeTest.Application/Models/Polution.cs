using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Application.Models
{
    public class Polution
    {
        [JsonProperty("time")]
        public DateTime MeasureDate { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("data")]
        public List<PolutionData> PolutionDetails { get; set; }
    }

    public class Location
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class PolutionData
    {
        public double Precision { get; set; }
        public double Pressure { get; set; }
        public double Value { get; set; }
    }
}
