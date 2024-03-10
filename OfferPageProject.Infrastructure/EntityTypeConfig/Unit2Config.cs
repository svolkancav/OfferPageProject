using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OfferPageProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Infrastructure.EntityTypeConfig
{
    public class Unit2Config : IEntityTypeConfiguration<Unit2>
    {
        public void Configure(EntityTypeBuilder<Unit2> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UnitType).IsRequired().HasMaxLength(3);
            builder.Property(u => u.Quantity).IsRequired().HasMaxLength(5); builder.HasMany(x => x.Offers)
                .WithOne(x => x.Unit2)
                .HasForeignKey(x => x.Unit2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
