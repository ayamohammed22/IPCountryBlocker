using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.DTO;

namespace ValidIpandBlockCountires.Service.Services
{
    public interface ITempBlockedCountryService
    {
        //public void cleanUpExpire();
        public string AddTemporalBlockedCountry(AddTemporalBlockedCountryDTO dto);
    }
}
