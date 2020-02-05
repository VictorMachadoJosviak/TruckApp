using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities;

namespace TruckApp.Domain.Map
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.YearManufacture).IsRequired(true);
            builder.Property(x => x.ModelYear).IsRequired(true);
            builder.Property(x => x.ModelId).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired(true);
        }
    }
}
