using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.IncoTermsService;
using OfferPageProject.Application.Services.MovementTypeService;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncoTermsController : Controller
    {
        private readonly IIncoTermsService _incoTermsService;

        public IncoTermsController(IIncoTermsService incoTermsService)
        {
            _incoTermsService = incoTermsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _incoTermsService.GetIncoTerms();
            return Ok(models);
        }
    }
}
