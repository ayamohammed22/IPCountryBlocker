using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Infrastructure.Repositories
{
    public interface ILogRepo
    {
        public void AddLog(string ipAddress, string userAgent, string countryCode, bool isblocked);
        public List<BlockedAttemptLog> GetAll(int page, int pageSize);
    }
}
