using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Infrastructure.Config
{
    public static class IPGeoConfig
    {
        public static IServiceCollection AddGeoApiSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GeoApiSettings>(configuration.GetSection("GeoApi"));
            return services;
        }
    }
}
