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
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Country)
                .WithMany(x=>x.Offers)
                .HasForeignKey(o => o.CountryId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(o => o.Unit1)
                .WithMany(x => x.Offers)
                .HasForeignKey(o => o.Unit1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Unit2)
                .WithMany(x => x.Offers)
                .HasForeignKey(o => o.Unit2Id).
                OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Mode)
            .WithMany(x => x.Offers)
            .HasForeignKey(o => o.ModeId).
            OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.MovementType)
                .WithMany(x => x.Offers)
                .HasForeignKey(o => o.MovementTypeId).
                OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Incoterms)
                .WithMany(x => x.Offers)
                .HasForeignKey(o => o.IncotermsId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
