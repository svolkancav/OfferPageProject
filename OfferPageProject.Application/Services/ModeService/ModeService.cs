using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.ModeService
{
    public class ModeService : IModeService
    {
        private readonly IModeRepository _modeRepository;

        public ModeService(IModeRepository modeRepository)
        {
            _modeRepository = modeRepository;
        }

        public async Task<List<ModeDTO>> GetModes()
        {
            try
            {
                return await _modeRepository.GetFilteredList(x => new ModeDTO
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
