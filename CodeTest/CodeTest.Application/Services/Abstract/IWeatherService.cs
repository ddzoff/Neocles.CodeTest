using CodeTest.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Application.Services.Abstract
{
    public interface IWeatherService
    {
        Task<Polution> GetWeatherPolution(string latitude, string longitude, string timestamp);
    }
}
