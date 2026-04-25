using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ValidIpandBlockCountires.Service.Services;
using ValidIPandBlockCountries.Core.Response;

namespace ValidIPandBlockedCountries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogCountroller : ControllerBase
    {
        private readonly ILogservice _logservice;

        public LogCountroller(ILogservice logservice)
        {
            _logservice = logservice;
        }

        [HttpGet("blocked-attempts")]
        public IActionResult GetLogs([FromQuery] int? pagesize, [FromQuery] int? page)
        {
            var logs = _logservice.GetAll(pagesize ?? 10, page ?? 1);
            return StatusCode((int)HttpStatusCode.OK,logs);
        }
    }
}
