using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceProject.Infrastructure.Database.EntityTypeConfiguration
{
    internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(p => p.Id).HasColumnName("CustomerId");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.UserName).HasColumnName("UserName");
            builder.Property(p => p.Email).HasColumnName("Email");
        }
    }
}
