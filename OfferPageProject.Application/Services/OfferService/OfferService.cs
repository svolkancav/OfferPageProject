using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OfferPageProject.Common.DTOs;
using OfferPageProject.Common.VM;
using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Domain.Enum;
using OfferPageProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferService(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateOfferDTO model)
        {
            Offer offer = new Offer
            {
                Id = model.Id,
                CityId = model.CityId,
                CountryId = model.CountryId,
                PackageType = model.PackageType,
                Currency = model.Currency,
                IncotermsId = model.IncotermsId,
                ModeId = model.ModeId,
                MovementTypeId = model.MovementTypeId,
                Unit1Id = model.Unit1Id,
                Unit2Id = model.Unit2Id
            };
            try
            {
                await _offerRepository.Create(offer);
            }
            catch (Exception message)
            {

                throw message;
            }
        }

        public async Task Delete(int id)
        {
            Offer offer = await _offerRepository.GetDefault(x => x.Id == id);
            if (id == 0)
            {
                throw new ArgumentException("Id can not be 0");
            }
            else if (offer == null)
            {
                throw new ArgumentException("Offer does not exist");
            }
            offer.DeletedDate = DateTime.Now;
            offer.Status = Status.Deleted;
            await _offerRepository.Delete(offer);
        }

        public async Task<OfferDTO> GetById(int id)
        {
            UpdateOfferDTO model = new UpdateOfferDTO();
            Offer offer = await _offerRepository.GetDefault(x =>x.Id == id);

            var mapOffer = _mapper.Map<OfferDTO>(offer);
            return mapOffer;

        }



        public async Task<List<OfferVM>> GetOffers()
        {
            return await _offerRepository.GetFilteredList( x=> new OfferVM
            {
                Id = x.Id,
                CityId = x.CityId,
                CountryId = x.CountryId,
                Currency = x.Currency,
                IncotermsId = x.IncotermsId,
                ModeId = x.ModeId,
                MovementTypeId = x.MovementTypeId,
                Unit1Id = x.Unit1Id,
                Unit2Id = x.Unit2Id,
                ModeName = x.Mode.Name,
                MovementTypeName = x.MovementType.Name,
                IncoTermsName = x.Incoterms.Name,
                CountryName = x.Country.Name,
                Unit1Type = x.Unit1.UnitType,
                Unit1Quantity = x.Unit1.Quantity,
                Unit2Type = x.Unit2.UnitType,
                Unit2Quantity = x.Unit2.Quantity,
                PackageType = x.PackageType

            }, x=>x.Status != Status.Deleted);
        }

        public async Task Update(UpdateOfferDTO model)
        {
            Offer offer = await _offerRepository.GetDefault(x => x.Id == model.Id);
            offer.Currency = model.Currency;
            offer.Unit1Id = model.Unit1Id;
            offer.Unit2Id = model.Unit2Id;
            offer.CityId = model.CityId;
            offer.CountryId = model.CountryId;
            offer.IncotermsId = model.IncotermsId;
            offer.ModeId = model.ModeId;
            offer.MovementTypeId = model.MovementTypeId;
            offer.ModifiedDate = DateTime.Now;
            offer.Status = Status.Updated;

            await _offerRepository.Update(offer);
        }
    }
}
