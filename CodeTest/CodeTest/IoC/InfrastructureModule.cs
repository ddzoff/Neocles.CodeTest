using CodeTest.Application.Contracts.ServiceAdapters;
using CodeTest.Infrastructure.Services;
using CodeTest.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace CodeTest.IoC
{
    public static class InfrastructureModule
    {
        public static void RegisterInfrastructureModule(this UnityContainer container)
        {
            OpenWeatherMapSettings openWeatherMapSettings = new OpenWeatherMapSettings();

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                openWeatherMapSettings.OpenWeatherApiBaseUrl = appSettings["OpenWeatherApiBaseUrl"];
                openWeatherMapSettings.OpenWeatherApiKey = appSettings["OpenWeatherApiKey"];
                openWeatherMapSettings.OpenWeatherApiPolutionPath = appSettings["OpenWeatherApiPolutionPath"];                
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Error reading app settings: {ex.Message}\n{ex.StackTrace}");
            }

            container.RegisterType<IWeatherServiceAdapter, WeatherServiceAdapter>(new HierarchicalLifetimeManager(), new InjectionConstructor(openWeatherMapSettings));
        }
    }
}