using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferPageProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Infrastructure.EntityTypeConfig
{
    public class Unit1Config : IEntityTypeConfiguration<Unit1>
    {
        public void Configure(EntityTypeBuilder<Unit1> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UnitType).IsRequired().HasMaxLength(3);
            builder.Property(u => u.Quantity).IsRequired().HasMaxLength(5); builder.HasMany(x => x.Offers)
                .WithOne(x => x.Unit1)
                .HasForeignKey(x => x.Unit1Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
