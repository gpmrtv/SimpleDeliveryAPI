using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Configuration
{
    public class OrderConfiguration : BaseEntityConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Orders");
            builder.Property(p => p.Cost).HasColumnName("Cost").HasColumnType("Decimal");
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(p => p.ExecutionDate).HasColumnName("ExecutionDate").IsRequired(false);
            //builder.HasOne(o => o.Customer).WithMany(m => m.Orders).IsRequired();
            //builder.HasOne(o => o.Performer).WithMany(m => m.Orders).IsRequired(false);
            builder.HasOne(o => o.Route).WithOne(o => o.Order).IsRequired().HasForeignKey(typeof(OrderEntity));
            //builder.HasOne(o => o.State).WithMany(m => m.Orders).IsRequired();
        }
    }
}
