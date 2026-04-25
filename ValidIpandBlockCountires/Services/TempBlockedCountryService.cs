using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIpandBlockCountires.Infrastructure.Repositories;
using ValidIPandBlockCountries.Core.DTO;

namespace ValidIpandBlockCountires.Service.Services
{
    public class TempBlockedCountryService : ITempBlockedCountryService
    {
        private readonly ITempBlockedCountryRepo _tempBlockedCountryRepo;

        public TempBlockedCountryService(ITempBlockedCountryRepo tempBlockedCountryRepo)
        {
            _tempBlockedCountryRepo = tempBlockedCountryRepo;
        }

        public string AddTemporalBlockedCountry(AddTemporalBlockedCountryDTO dto)
        {
            var expiryTime = DateTime.UtcNow.AddMinutes(dto.durationMinutes);
            return _tempBlockedCountryRepo.AddTempBlockedCountry(dto.CountryCode, expiryTime);
        }

    }
}
