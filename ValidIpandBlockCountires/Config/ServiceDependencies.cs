using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIpandBlockCountires.Service.Services;

namespace ValidIpandBlockCountires.Service.Config
{
    public static class ServiceDependencies 
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection service)
        {
            service.AddScoped<ICountriesService,CountriesService>();
            service.AddScoped<ITempBlockedCountryService,TempBlockedCountryService>();
            service.AddScoped<ILogservice,LogService>();
          
            return service;
        }
    }
}
