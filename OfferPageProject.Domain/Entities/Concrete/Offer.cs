
using OfferPageProject.Domain.Entities.Abstract;
using OfferPageProject.Domain.Enum;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class Offer : BaseEntity, IEntity<int>
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public int Unit1Id { get; set; }
        public Unit1 Unit1 { get; set; }
        public int Unit2Id { get; set; }
        public Unit2 Unit2 { get; set; }
        public Currency Currency { get; set; }
        public int ModeId { get; set; }
        public Mode Mode { get; set; }
        public int MovementTypeId { get; set; }
        public MovementType MovementType { get; set; }
        public int IncotermsId { get; set; }
        public Incoterms Incoterms { get; set; }
        public PackageType PackageType { get; set; }
        
        
        
        
        
        

    }
}
