using OfferPageProject.Domain.Enum;

namespace OfferPageProject.Common.VM
{
    public class OfferVM
    {
        public int Id { get; set; }
        public int ModeId { get; set; }
        public string ModeName { get; set; }
        public int MovementTypeId { get; set; }
        public string MovementTypeName { get; set; }
        public int IncotermsId { get; set; }
        public string IncoTermsName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }

        public int Unit1Id { get; set; }
        public int Unit1Quantity { get; set; }
        public string Unit1Type { get; set; }

        public int Unit2Id { get; set; }
        public int Unit2Quantity { get; set; }
        public string Unit2Type { get; set; }
        public Currency Currency { get; set; }
        public PackageType PackageType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
