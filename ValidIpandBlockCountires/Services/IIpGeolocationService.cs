using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.DTO;

namespace ValidIpandBlockCountires.Service.Services
{
    public interface IIpGeolocationService
    {
        public Task<IpInfoDTO> GetIpInfoAsync(string ipAddress);
        public Task<bool> CheckCountryIsBlock(string ipAddress , string userAgent);
    }
}
