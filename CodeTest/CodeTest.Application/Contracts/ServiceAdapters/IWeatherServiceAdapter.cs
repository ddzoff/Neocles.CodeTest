using CodeTest.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Application.Contracts.ServiceAdapters
{
    public interface IWeatherServiceAdapter
    {
        Task<string> GetPolutionData(decimal latitude, decimal longitude, DateTime date);
    }
}
