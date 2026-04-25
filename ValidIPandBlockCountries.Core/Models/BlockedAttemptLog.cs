using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIPandBlockCountries.Core.Models
{
    public class BlockedAttemptLog
    {
        public string IP { get; set; }
        public string CountryCode { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsBlocked { get; set; }
        public string UserAgent { get; set; }

    }
}
