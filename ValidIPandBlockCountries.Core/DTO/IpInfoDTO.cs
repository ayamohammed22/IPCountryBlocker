using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIPandBlockCountries.Core.DTO
{
    public class IpInfoDTO
    {
        public string ip { get; set; }
        public string country_code2 { get ; set; }
        public string country_name { get ; set; }
        public string isp { get ; set; }
    }
}
