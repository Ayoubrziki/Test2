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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable(nameof(Flight));

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(x => x.DepartureAirport)
                .WithMany(x => x.DepartureAirportFlights)
                .HasForeignKey(x => x.DepartureAirportId)
                .HasPrincipalKey(o => o.Id);

            builder.HasOne(x => x.ArrivalAirport)
                .WithMany(x => x.ArrivalAirportFlights)
                .HasForeignKey(x => x.DepartureAirportId)
                .HasPrincipalKey(o => o.Id);
        }
    }
}
