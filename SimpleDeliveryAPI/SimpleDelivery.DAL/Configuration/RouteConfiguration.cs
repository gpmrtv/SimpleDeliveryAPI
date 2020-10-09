using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Configuration
{
    public class RouteConfiguration : BaseEntityConfiguration<RouteEntity>
    {
        public override void Configure(EntityTypeBuilder<RouteEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Routes");
            builder.Property(p => p.StartPoint).HasColumnName("StartPoint").HasMaxLength(30);
            builder.Property(p => p.FinishPoint).HasColumnName("FinishPoint").HasMaxLength(20);
        }
    }
}
