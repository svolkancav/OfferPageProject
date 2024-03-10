using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.Unit1Service
{
    public class Unit1Service : IUnit1Service
    {
        private readonly IUnit1Repository _unit1Repository;

        public Unit1Service(IUnit1Repository unit1Repository)
        {
            _unit1Repository = unit1Repository;
        }

        public async Task<List<Unit1DTO>> GetUnit1s()
        {
            try
            {
                return await _unit1Repository.GetFilteredList(x => new Unit1DTO
                {
                    Id = x.Id,
                    UnitType = x.UnitType,
                    Quantity = x.Quantity,
                }, x => x.Status != Domain.Enum.Status.Deleted);
            }
            catch (Exception message)
            {

                throw message;
            }
        }
    }
}
