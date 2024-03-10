using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.Unit1Service;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Unit1Controller : Controller
    {
        private readonly IUnit1Service _unit1Service;

        public Unit1Controller(IUnit1Service unit1Service)
        {
            _unit1Service = unit1Service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _unit1Service.GetUnit1s();
            return Ok(models);
        }
    }
}
