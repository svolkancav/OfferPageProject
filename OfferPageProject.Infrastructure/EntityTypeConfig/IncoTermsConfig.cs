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
    public class IncotermsConfig : IEntityTypeConfiguration<Incoterms>
    {
        public void Configure(EntityTypeBuilder<Incoterms> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Description).HasMaxLength(250);
            builder.HasMany(x => x.Offers)
                .WithOne(x => x.Incoterms)
                .HasForeignKey(x => x.IncotermsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
