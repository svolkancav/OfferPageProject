using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.ModeService;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeController : Controller
    {
        private readonly IModeService _modeService;

        public ModeController(IModeService modeService)
        {
            _modeService = modeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _modeService.GetModes();
            return Ok(models);
        }
    }
}
