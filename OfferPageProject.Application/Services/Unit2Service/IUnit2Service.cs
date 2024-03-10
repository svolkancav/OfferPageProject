using OfferPageProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.Unit2Service
{
    public interface IUnit2Service
    {
        Task<List<Unit2DTO>> GetUnit2s();
    }
}
