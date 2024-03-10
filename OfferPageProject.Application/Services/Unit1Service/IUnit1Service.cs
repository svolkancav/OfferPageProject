using OfferPageProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.Unit1Service
{
    public interface IUnit1Service
    {
        Task<List<Unit1DTO>> GetUnit1s();
    }
}
