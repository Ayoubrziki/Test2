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
    public class GPSLocationConfiguration : IEntityTypeConfiguration<GPSLocation>
    {
        public void Configure(EntityTypeBuilder<GPSLocation> builder)
        {
            builder.ToTable(nameof(GPSLocation));

            builder.HasKey(f => f.Id);
        }
    }
}
