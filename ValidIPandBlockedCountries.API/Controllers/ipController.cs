using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ValidIpandBlockCountires.Service.Services;
using ValidIPandBlockCountries.Core.DTO;
using ValidIPandBlockCountries.Core.Response;

namespace ValidIPandBlockedCountries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ipController : ControllerBase
    {
        private readonly IIpGeolocationService _ipGeolocationService;
        public ipController(IIpGeolocationService ipGeolocationService)
        {
            _ipGeolocationService = ipGeolocationService;
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetCountrywithIp([FromQuery] string ipAddress)
        {
            
            if (string.IsNullOrEmpty(ipAddress))
            {
                return StatusCode((int)HttpStatusCode.NotFound, new BaseResponse<string>()
                {
                    Data = null,
                    Success = false,
                    Message = "IP address is required."

                });
            }
            try
            {
                var response = await _ipGeolocationService.GetIpInfoAsync(ipAddress);
                return StatusCode((int)HttpStatusCode.OK, new BaseResponse<IpInfoDTO>(){
                    Data = response,
                    Success = true,
                    Message = "IP information retrieved successfully."
                });
            }
                catch(Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new BaseResponse<string>(){
                        Data = null,
                        Success = false,
                        Message = ex.Message

                    });
            }
            
            
        }

        [HttpGet("check-block")]
        public async Task<IActionResult> CheckCountryBlocked()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            if (string.IsNullOrEmpty(ipAddress) || ipAddress == "::1") // that's for localhost testing
            {
                ipAddress = "41.67.100.1"; // Default to a known IP for testing
            }
            try
            {
                var isBlocked = await _ipGeolocationService.CheckCountryIsBlock(ipAddress, Request.Headers["User-Agent"]);
                return StatusCode((int)HttpStatusCode.OK, new BaseResponse<bool>()
                {
                    Data = isBlocked,
                    Success = true,
                    Message = "Country block status retrieved successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new BaseResponse<string>()
                {
                    Data = null,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
