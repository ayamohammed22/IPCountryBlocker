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
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly ITempBlockedCountryService _tempCountriesService;

        public CountriesController(ICountriesService countriesService, ITempBlockedCountryService tempCountriesService)
        {
            _countriesService = countriesService;
            _tempCountriesService = tempCountriesService;
        }

        // 1. Add a Blocked Country
        [HttpPost("block")]
        public IActionResult BlockCountry([FromBody] AddBlockedCountryDTO dto)
        {

            var result = _countriesService.AddBlockedCountry(dto);
            if (result == "This Country aready exists in the blocked list.")
            {
                return StatusCode((int)HttpStatusCode.Conflict, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }
            else if (result == "Country added to the blocked list successfully.")
            {
                return StatusCode((int)HttpStatusCode.Created, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = true,

                });
            }
            else if (result == "Country code cannot be null.")
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }
        }


        [HttpDelete("block/{countryCode}")]
        public IActionResult UnblockCountry([FromRoute] string countryCode)
        {
            var result = _countriesService.RemoveBlockedCountry(new RemoveBlockedCountryDTO() { CountryCode = countryCode });
            if (result == "This Country do not exist in the blocked list.")
            {
                return StatusCode((int)HttpStatusCode.NotFound, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }
            else if (result == "Country deleted to the blocked list successfully.")
            {
                return StatusCode((int)HttpStatusCode.OK, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = true,
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }
        }


        [HttpGet("blocked")]
        public IActionResult BlockedCountries([FromQuery] int? pagesize, [FromQuery] int? page, [FromQuery] string? filter)
        {
            var result = _countriesService.GetAllBlockedCountry(pagesize, page, filter);

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost("temporal-block")]
        public IActionResult TemporalBlockCountry([FromBody] AddTemporalBlockedCountryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CountryCode) || dto.CountryCode == "" || dto.durationMinutes <= 0 || dto.durationMinutes > 1440)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new BaseResponse<string>()
                {
                    Data = null,
                    Message = "Country code cannot be null and duration must be greater than zero and less than 1440.",
                    Success = false
                });
            }
            var result = _tempCountriesService.AddTemporalBlockedCountry(dto);
            if (result == "This Country aready exists in the temporary blocked list.")
            {
                return StatusCode((int)HttpStatusCode.Conflict, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }
            else if (result == "Country added to the temporary blocked list successfully.")
            {
                return StatusCode((int)HttpStatusCode.Created, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = true,
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BaseResponse<string>()
                {
                    Data = null,
                    Message = result,
                    Success = false
                });
            }

        }
    }
}
