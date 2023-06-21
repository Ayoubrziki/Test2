using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.ToTable(nameof(Airport));

            builder.Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired();
            
            builder.Property(x => x.Code)
                .HasMaxLength(3)
                .IsRequired();

            builder.HasOne(x => x.Location)
                .WithOne(x => x.Airport)
                .HasForeignKey<Airport>(x => x.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
