using OfferPageProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.IncoTermsService
{
    public interface IIncoTermsService
    {
        Task<List<IncoTermsDTO>> GetIncoTerms();
    }
}
