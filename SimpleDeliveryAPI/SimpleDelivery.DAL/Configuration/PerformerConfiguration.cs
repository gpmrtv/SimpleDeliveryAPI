using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Configuration
{
    public class PerformerConfiguration : BaseEntityConfiguration<PerformerEntity>
    {
        public override void Configure(EntityTypeBuilder<PerformerEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Performers");
            builder.Property(p => p.Password).HasColumnName("Password").HasMaxLength(30);
            builder.Property(p => p.Login).HasColumnName("Login").HasMaxLength(20);
            builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(12);
            builder.Property(p => p.Name).HasColumnName("FirstName").HasMaxLength(20);
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(20);
            builder.Property(p => p.IsVerified).HasColumnName("IsVerified");
            builder.HasMany(m => m.Orders).WithOne(o => o.Performer).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            builder.HasMany(m => m.Vehicle).WithOne(o => o.Driver).OnDelete(DeleteBehavior.Cascade).IsRequired(false);

        }
    }
}
