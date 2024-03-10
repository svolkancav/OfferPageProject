using OfferPageProject.Domain.Entities.Abstract;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class Incoterms : BaseEntity, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
