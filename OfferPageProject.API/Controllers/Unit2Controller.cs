using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.Unit2Service;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Unit2Controller : Controller
    {
        private readonly IUnit2Service _unit2Service;

        public Unit2Controller(IUnit2Service unit2Service)
        {
            _unit2Service = unit2Service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _unit2Service.GetUnit2s();
            return Ok(models);
        }
    }
}
