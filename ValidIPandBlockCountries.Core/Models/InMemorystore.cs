using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIPandBlockCountries.Core.Models
{
    public class InMemorystore
    {
        public ConcurrentDictionary<string, string> BlockedCountries { get; } = new();

        public ConcurrentDictionary<string, DateTime> TempBlockedCountries { get; } = new();

        public ConcurrentBag<BlockedAttemptLog> Logs { get; } = new();
    }
}
