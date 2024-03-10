using OfferPageProject.Domain.Entities.Concrete;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Offer> Offers { get; set; }

    }
}
