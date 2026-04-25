using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIPandBlockCountries.Core.DTO
{
    public class AddTemporalBlockedCountryDTO
    {
        public string CountryCode { get; set; }
        public int durationMinutes { get; set; }
    }
}
