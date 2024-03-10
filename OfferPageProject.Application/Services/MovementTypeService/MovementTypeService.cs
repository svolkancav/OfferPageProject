using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.MovementTypeService
{
    public class MovementTypeService : IMovementTypeService
    {
        private readonly IMovementTypeRepository _movementTypeRepository;

        public MovementTypeService(IMovementTypeRepository movementTypeRepository)
        {
            _movementTypeRepository = movementTypeRepository;
        }

        public async Task<List<MovementTypeDTO>> GetMovementTypes()
        {
            try
            {
                return await _movementTypeRepository.GetFilteredList(x => new MovementTypeDTO
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
