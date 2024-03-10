using OfferPageProject.Domain.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OfferPageProject.Common.DTOs
{
    public class CreateOfferDTO
    {
        public int Id { get; set; }
        public int ModeId { get; set; }
        public int MovementTypeId { get; set; }
        public int IncotermsId { get; set; }
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public int Unit1Id { get; set; }
        public int Unit2Id { get; set; }
        public Currency Currency { get; set; }
        public PackageType PackageType { get; set; }


        public List<SelectListItem>? CityList { get; set; }
        public List<SelectListItem>? CountryList { get; set; }
        public List<SelectListItem>? ModeList { get; set; }
        public List<SelectListItem>? MovementTypeList { get; set; }
        public List<SelectListItem>? IncoTermsList { get; set; }
        public List<SelectListItem>? CurrencyList { get; set; }
        public List<SelectListItem>? Unit1List { get; set; }
        public List<SelectListItem>? Unit2List { get; set; }





    }
}
