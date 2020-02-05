using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities;

namespace TruckApp.Domain.Map
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Name).HasMaxLength(2).IsRequired(true);       
        }
    }
}
