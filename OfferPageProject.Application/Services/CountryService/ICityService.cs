using OfferPageProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.CountryService
{
    public interface ICityService
    {
        Task<CityDTO> GetCityByIdAsync(int cityId);
        Task<List<CityDTO>> GetCities();
    }
}
