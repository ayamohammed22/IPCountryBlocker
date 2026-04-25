using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Service.Services
{
    public interface ILogservice
    {
        public List<BlockedAttemptLog> GetAll(int page, int pageSize);
    }
}
