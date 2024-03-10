using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.CountryService;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries = await _countryService.GetCountries();
            return Ok(countries);
        }
    }
}
