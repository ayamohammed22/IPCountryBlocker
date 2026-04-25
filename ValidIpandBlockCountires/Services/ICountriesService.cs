using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.DTO;

namespace ValidIpandBlockCountires.Service.Services
{
    public interface ICountriesService
    {
        public string AddBlockedCountry(AddBlockedCountryDTO dto);
        public string RemoveBlockedCountry(RemoveBlockedCountryDTO dto);
        public List<string> GetAllBlockedCountry(int? pagesize, int? page, string? filter);
    }
}
