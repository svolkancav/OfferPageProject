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
    public class MovementTypeConfig : IEntityTypeConfiguration<MovementType>
    {
        public void Configure(EntityTypeBuilder<MovementType> builder)
        {
            builder.HasKey(mt => mt.Id);
            builder.Property(mt => mt.Name).IsRequired().HasMaxLength(50);
            builder.Property(mt => mt.Description).HasMaxLength(250);
            builder.HasMany(x => x.Offers)
                .WithOne(x => x.MovementType)
                .HasForeignKey(x => x.MovementTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
