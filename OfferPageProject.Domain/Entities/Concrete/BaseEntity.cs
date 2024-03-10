using OfferPageProject.Domain.Entities.Abstract;
using OfferPageProject.Domain.Enum;

namespace OfferPageProject.Domain.Entities.Concrete
{
    public class BaseEntity : IBaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        virtual public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; } = Status.Inserted;
    }
}
