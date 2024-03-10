﻿using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Infrastructure.Repositories
{
    public class OfferRepository : BaseRepository<Offer>,IOfferRepository
    {
        public OfferRepository (AppDbContext context) : base (context) { }
    }
}
