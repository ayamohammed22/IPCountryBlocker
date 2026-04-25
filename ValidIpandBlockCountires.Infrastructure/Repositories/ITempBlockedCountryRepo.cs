using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIpandBlockCountires.Infrastructure.Repositories
{
    public interface ITempBlockedCountryRepo
    {
        //public void RemoveExpireBlockedCountry(DateTime now);

        public string AddTempBlockedCountry(string countryCode, DateTime expireTime);
    }
}
