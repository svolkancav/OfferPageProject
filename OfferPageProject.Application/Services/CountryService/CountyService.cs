using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.CountryService
{
    public class CountyService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountyService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<CountryDTO>> GetCountries()
        {
            try
            {
                return await _countryRepository.GetFilteredList(x => new CountryDTO
                {
                    CountryId = x.Id,
                    Name = x.Name,
                    Cities = x.Cities
                }, x=>x.Status != Domain.Enum.Status.Deleted);
            }
            catch (Exception message)
            {

                throw message;
            }
        }
    }
}
