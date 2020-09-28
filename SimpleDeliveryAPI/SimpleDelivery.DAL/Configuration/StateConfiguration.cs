using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelivery.DAL.Configuration
{
    public class StateConfiguration : BaseEntityConfiguration<StateEntity>
    {
        public override void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("States");
            builder.Property(p => p.Name).HasColumnName("StateName").HasMaxLength(30);
            builder.HasMany(m => m.Orders).WithOne(o => o.State).IsRequired(true);
        }
    }
}
