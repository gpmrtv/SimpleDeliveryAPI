using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Configuration
{
    public class VehicleTypeConfiguration : BaseEntityConfiguration<VehicleTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<VehicleTypeEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("VehicleTypes");
            builder.Property(p => p.MaxCarrying).HasColumnName("MaxCarrying");
            builder.Property(p => p.Name).HasColumnName("TypeName").HasMaxLength(30);
            builder.HasMany(m => m.Vehicles).WithOne(o => o.VehicleType).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
        }
    }
}
