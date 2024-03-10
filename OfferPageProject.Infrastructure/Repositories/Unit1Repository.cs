using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Infrastructure.Repositories
{
    public class Unit1Repository : BaseRepository<Unit1>, IUnit1Repository
    {
        public Unit1Repository(AppDbContext context) : base(context)
        {
        }
    }
}
