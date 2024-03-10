using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.IncoTermsService
{
    public class IncoTermsService : IIncoTermsService
    {
        private readonly IIncoTermsRepository _incoTermsRepository;

        public IncoTermsService(IIncoTermsRepository incoTermsRepository)
        {
            _incoTermsRepository = incoTermsRepository;
        }

        public async Task<List<IncoTermsDTO>> GetIncoTerms()
        {
            try
            {
                return await _incoTermsRepository.GetFilteredList(x => new IncoTermsDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                }, x => x.Status != Domain.Enum.Status.Deleted);
            }
            catch (Exception message)
            {

                throw message;
            }
        }
    }
}
