using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.CountryService;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cities = await _cityService.GetCities();
            return Ok(cities);
        }
    }
}
