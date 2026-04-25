using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ValidIpandBlockCountires.Infrastructure.Repositories;
using ValidIPandBlockCountries.Core.DTO;

namespace ValidIpandBlockCountires.Service.Services
{
    public class IpGeolocationService : IIpGeolocationService
    {
        private readonly HttpClient _http;
        private readonly ICountriesRepo _countriesRepo;
        private readonly ILogRepo _logRepo;
        private readonly string _apiKey;
        private readonly string _baseUrl;


        public IpGeolocationService(HttpClient http,IConfiguration configuration,
                                    ICountriesRepo countriesRepo, ILogRepo logRepo)
        {
            _http = http;
            _countriesRepo = countriesRepo;
            _logRepo = logRepo;
            _baseUrl = configuration["GeoApi:BaseUrl"];
            _apiKey = configuration["GeoApi:ApiKey"];
        }

        public async Task<bool> CheckCountryIsBlock(string ipAddress,string userAgent)
        {
            var countryInfo =await GetIpInfoAsync(ipAddress);
            var country = _countriesRepo.GetAll(1,1,countryInfo.country_code2);
            _logRepo.AddLog(ipAddress, userAgent, countryInfo.country_code2, (country.Count == 0) ? false : true);
            return (country.Count == 0) ? false:true;
        }

        public async Task<IpInfoDTO> GetIpInfoAsync(string ipAddress)
        {
            // Validation: Make sure it’s a valid IP Format 
            if(!System.Net.IPAddress.TryParse(ipAddress, out _))
            {
                throw new ArgumentException("Invalid IP address format.");
            }
            var url = $"{_baseUrl}?apiKey={_apiKey}&ip={ipAddress}";
            var response = await _http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve IP information.");
            }
            var content = await response.Content.ReadAsStringAsync();
            var ipInfo = System.Text.Json.JsonSerializer.Deserialize<IpInfoDTO>(content);
            return ipInfo;
        }
    }
}
