using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidIpandBlockCountires.Infrastructure.Repositories;
using ValidIPandBlockCountries.Core.DTO;

namespace ValidIpandBlockCountires.Service.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepo _countriesRepo;
        public CountriesService(ICountriesRepo countriesRepo) {
            _countriesRepo = countriesRepo;
        }
        public string AddBlockedCountry(AddBlockedCountryDTO dto)
        {
            if (dto.CountryCode == ""||dto.CountryCode == null)
            {
                return "Country code cannot be null.";
            }
           return _countriesRepo.AddBlockedCountry(dto.CountryCode);
        }

        public List<string> GetAllBlockedCountry(int? pagesize, int? page, string? filter)
        {
            if (page == null || pagesize < 1)
            {
                pagesize = 10;
            }
            if(page == null || page < 1)
            {
                page = 1;
            }
           var result =  _countriesRepo.GetAll(pagesize.Value, page.Value, filter).ToList();
            return result;

        }

        public string RemoveBlockedCountry(RemoveBlockedCountryDTO dto)
        { 
            return _countriesRepo.RemoveBlockedCountry(dto.CountryCode);
        }

    }
}
