using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Infrastructure.Repositories
{
    public class LogRepo : ILogRepo
    {
        private readonly InMemorystore _store;
        public LogRepo(InMemorystore store)
        {
            _store = store;
        }

        public void AddLog(string ipAddress, string userAgent, string countryCode, bool isblocked)
        {
            var log = new BlockedAttemptLog
            {
                Timestamp = DateTime.UtcNow,
                IP = ipAddress,
                UserAgent = userAgent,
                CountryCode = countryCode,
                IsBlocked = isblocked
            };
            _store.Logs.Add(log);
        }

        public List<BlockedAttemptLog> GetAll(int page, int pageSize)
        {
            var query = _store.Logs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return query;
        }
    }
}
