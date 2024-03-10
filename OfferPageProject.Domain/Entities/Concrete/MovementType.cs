using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class MovementType : BaseEntity, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
