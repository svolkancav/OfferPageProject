using Microsoft.EntityFrameworkCore;
using OfferPageProject.Domain.Entities.Concrete;
using OfferPageProject.Infrastructure.EntityTypeConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Unit1> Unit1s { get; set; }
        public DbSet<Unit2> Unit2s { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<Incoterms> Incotermses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfferConfig());
            modelBuilder.ApplyConfiguration(new Unit1Config ());
            modelBuilder.ApplyConfiguration(new Unit2Config());
            modelBuilder.ApplyConfiguration(new ModeConfig());
            modelBuilder.ApplyConfiguration(new MovementTypeConfig());
            modelBuilder.ApplyConfiguration(new IncotermsConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
