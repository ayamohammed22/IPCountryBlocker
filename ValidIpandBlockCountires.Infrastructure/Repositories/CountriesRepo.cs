using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.DTO;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Infrastructure.Repositories
{
    public class CountriesRepo : ICountriesRepo
    {
        private readonly InMemorystore _data;
        public CountriesRepo(InMemorystore data) 
        {
            _data = data;
        }

        public string AddBlockedCountry(string countryCode)
        {
            if (Exists(countryCode))
            {
                return "This Country aready exists in the blocked list.";
            }
            bool result = _data.BlockedCountries.TryAdd(countryCode, countryCode);
            if (result)
            {
                return "Country added to the blocked list successfully.";
            }
            else
            {
                return "Failed to add the country to the blocked list.";
            }
        }
        public string RemoveBlockedCountry(string countryCode)
        {
            if (!Exists(countryCode))
            {
                return "This Country do not exist in the blocked list.";
            }
            bool result = _data.BlockedCountries.TryRemove(countryCode, out _);
            if (result)
            {
                return "Country deleted to the blocked list successfully.";
            }
            else
            {
                return "Failed to delete the country to the blocked list.";
            }
        }

        public List<string> GetAll(int pagesize, int page, string? filter)
        {
            var Qdata = _data.BlockedCountries.Keys.AsQueryable();

            var TempQdata = _data.TempBlockedCountries.Where(country => country.Value < DateTime.UtcNow)
                                                     .Select(country => country.Key);
            Qdata = Qdata.Concat(TempQdata);

            if (!string.IsNullOrEmpty(filter))
            {
                Qdata = Qdata.Where(c => c.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }
            return Qdata.Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }

        public bool Exists(string code)
        {
            return _data.BlockedCountries.ContainsKey(code);
        }
    }
}
