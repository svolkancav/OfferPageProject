using OfferPageProject.Common.DTOs;
using OfferPageProject.Common.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.OfferService
{
    public interface IOfferService
    {
        Task Create(CreateOfferDTO model);
        Task Update(UpdateOfferDTO model);
        Task Delete(int id);
        Task<OfferDTO> GetById(int id);
        Task<List<OfferVM>> GetOffers();


    }
}
