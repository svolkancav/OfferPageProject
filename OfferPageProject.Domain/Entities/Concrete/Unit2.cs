using OfferPageProject.Domain.Entities.Abstract;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class Unit2 : BaseEntity, IEntity<int>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string UnitType { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
