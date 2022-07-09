using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Client.Extensions
{
    public static class ApiServicesExtensions
    {
        public static void AddWeatherService(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherService, WeatherService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:44388/");
            });
        }
    }
}
