using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDelivery.DAL.Models;

namespace SimpleDelivery.DAL.Configuration
{
    public class CustomerConfiguration : BaseEntityConfiguration<CustomerEntity>
    {
        public override void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Customers");
            builder.Property(p => p.Password).HasColumnName("Password").HasMaxLength(30);
            builder.Property(p => p.Login).HasColumnName("Login").HasMaxLength(20);
            builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(12);
            builder.Property(p => p.Name).HasColumnName("FirstName").HasMaxLength(20);
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(20);
            builder.HasMany(m => m.Orders).WithOne(o => o.Customer).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}
