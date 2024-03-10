using OfferPageProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.MovementTypeService
{
    public interface IMovementTypeService
    {
        Task<List<MovementTypeDTO>> GetMovementTypes();
    }
}
