using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityConfigs
{
    internal sealed class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(k => k.Id);
            builder.HasMany(c => c.Orders).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Property("Id").HasColumnName("CustomerId");
            builder.Property("Name").HasColumnName("Name").HasMaxLength(150).IsRequired();
            builder.Property("UserName").HasColumnName("UserName").HasMaxLength(100).IsRequired();
            builder.Property("Email").HasColumnName("Email").HasMaxLength(150).IsRequired();
        }
    }
}
