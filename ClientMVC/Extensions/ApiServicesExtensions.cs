using Client.Services;
using ClientMVC.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Client.Extensions
{
    public static class ApiServicesExtensions
    {
        public static void AddWeatherService(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>(c =>
            {
                //TODO: Mover a AppSettings
                c.BaseAddress = new Uri("https://localhost:44388/");
            });
        }
    }
}
