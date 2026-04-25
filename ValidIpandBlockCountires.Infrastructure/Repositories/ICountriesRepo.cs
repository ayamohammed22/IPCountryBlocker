using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIpandBlockCountires.Infrastructure.Repositories
{
    public interface ICountriesRepo
    {
        public string AddBlockedCountry(string countryCode);
        public string RemoveBlockedCountry(string countryCode);
        public List<string> GetAll(int pagesize, int page, string? filter);
        public bool Exists(string code);
    }
}
