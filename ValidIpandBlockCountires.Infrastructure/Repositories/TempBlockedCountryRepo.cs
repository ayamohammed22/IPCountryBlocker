using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Infrastructure.Repositories
{
    public class TempBlockedCountryRepo : ITempBlockedCountryRepo
    {
        private readonly InMemorystore _store;

        public TempBlockedCountryRepo(InMemorystore store)
        {
            _store = store;
        }

        public string AddTempBlockedCountry(string countryCode, DateTime expireTime)
        {
            var exist = _store.TempBlockedCountries.ContainsKey(countryCode);
            if (exist)
            {
                return "This Country aready exists in the temporary blocked list.";
            }
            var result = _store.TempBlockedCountries.TryAdd(countryCode, expireTime);
            if (result)
            {
                return "Country added to the temporary blocked list successfully.";
            }
            else
            {
                return "Failed to add the country to the temporary blocked list.";

            }
        }
    }
}
