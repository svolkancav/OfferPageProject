using AutoMapper;
using OfferPageProject.Common.DTOs;
using OfferPageProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Offer, CreateOfferDTO>().ReverseMap();
            CreateMap<Offer, UpdateOfferDTO>().ReverseMap();
        }    
        
    }
}
