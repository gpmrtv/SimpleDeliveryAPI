using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;

namespace SimpleDelivery.DAL.Configuration
{
    public class VehicleConfiguration : BaseEntityConfiguration<VehicleEntity>
    {
        public override void Configure(EntityTypeBuilder<VehicleEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Vehicles");
            builder.Property(p => p.Brand).HasColumnName("Brand").HasMaxLength(15);
            builder.Property(p => p.Model).HasColumnName("Model").HasMaxLength(15);
            builder.Property(p => p.Color).HasColumnName("Color").HasMaxLength(20);
            builder.Property(p => p.Number).HasColumnName("Number").HasMaxLength(10);
            builder.HasOne(o => o.Driver).WithMany(m => m.Vehicles).IsRequired(false);
            builder.HasOne(o => o.VehicleType).WithMany(m => m.Vehicles).OnDelete(DeleteBehavior.Cascade).IsRequired(true);
        }
    }
}
