using Microsoft.AspNetCore.Mvc;
using OfferPageProject.Application.Services.OfferService;
using OfferPageProject.Common.DTOs;

namespace OfferPageProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _offerService.GetOffers();
            return Ok(offers);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var offer = await _offerService.GetById(Convert.ToInt32(id));
            return Ok(offer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDTO model)
        {
            await _offerService.Create(model);
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOfferDTO model)
        {
            await _offerService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _offerService.Delete(id);
            return Ok();
        }

    }
}
