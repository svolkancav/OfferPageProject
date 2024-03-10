using OfferPageProject.Application.Services.Unit1Service;
using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.Unit2Service
{
    public class Unit2Service : IUnit2Service
    {
        private readonly IUnit2Repository _unit2Repository;

        public Unit2Service(IUnit2Repository unit2Repository)
        {
            _unit2Repository = unit2Repository;
        }

        public async Task<List<Unit2DTO>> GetUnit2s()
        {
            try
            {
                return await _unit2Repository.GetFilteredList(x => new Unit2DTO
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
