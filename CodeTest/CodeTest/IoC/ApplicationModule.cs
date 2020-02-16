using CodeTest.Application.Services;
using CodeTest.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace CodeTest.IoC
{
    public static class ApplicationModule
    {
        public static void RegisterApplicationModule(this UnityContainer container)
        {
            container.RegisterType<IWeatherService, WeatherService>(new HierarchicalLifetimeManager());
        }
    }
}