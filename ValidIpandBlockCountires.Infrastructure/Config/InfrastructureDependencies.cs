using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIpandBlockCountires.Infrastructure.Repositories;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Infrastructure.Config
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            service.AddScoped<ICountriesRepo, CountriesRepo>();
            service.AddScoped<ITempBlockedCountryRepo, TempBlockedCountryRepo>();
            service.AddScoped<ILogRepo, LogRepo>();

            service.AddSingleton<InMemorystore>();
            return service;
        }
    }
}
