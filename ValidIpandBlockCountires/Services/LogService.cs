using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIpandBlockCountires.Infrastructure.Repositories;
using ValidIPandBlockCountries.Core.Models;

namespace ValidIpandBlockCountires.Service.Services
{
    public class LogService : ILogservice
    {
        private readonly ILogRepo _repo;
        public LogService(ILogRepo repo) {
            _repo = repo; 
        }
        public List<BlockedAttemptLog> GetAll(int page, int pageSize)
        {
            if(page <=0)
                page = 1;
            if (pageSize <= 0)
                pageSize = 10;
             return _repo.GetAll(page, pageSize);
        }
    }
}
