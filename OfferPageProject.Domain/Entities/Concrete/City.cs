using OfferPageProject.Domain.Entities.Concrete;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Offer>? Offers { get; set; }
    }
}
