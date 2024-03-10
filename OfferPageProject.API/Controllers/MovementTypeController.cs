using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.ModeService;
using OfferPageProject.Application.Services.MovementTypeService;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementTypeController : Controller
    {
        private readonly IMovementTypeService _movementTypeService;

        public MovementTypeController(IMovementTypeService movementTypeService)
        {
            _movementTypeService = movementTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _movementTypeService.GetMovementTypes();
            return Ok(models);
        }
    }
}
