using AutoMapper;
using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Domain.Enum;
using OfferPageProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.CountryService
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityDTO>> GetCities()
        {
            return await _cityRepository.GetFilteredList(x => new CityDTO
            {
                CityId = x.Id,
                Name = x.Name,
                Country = x.Country,
                CountryId = x.CountryId
            }, x => x.Status != Status.Deleted);
        }

        public async Task<CityDTO> GetCityByIdAsync(int cityId)
        {
            CityDTO model = new CityDTO();

            City city = await _cityRepository.GetDefault(x => x.Id == cityId);

            return _mapper.Map<CityDTO>(city);
        }
    }
}
