using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityTypeConfiguration
{
    internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("CustomerId").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.UserName).HasColumnName("UserName");
            builder.Property(p => p.Email).HasColumnName("Email");
        }
    }
}
