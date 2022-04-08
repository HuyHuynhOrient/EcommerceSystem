using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SharedKermel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityTypeConfiguration
{
    internal class OrderProductEntityTypeConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");

            builder.Property(p => p.Id).HasColumnName("OrderProductId").UseIdentityColumn();
            builder.HasKey(k => k.Id);
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.HasOne<Product>().WithMany();

            builder.Property(p => p.Quantity).HasColumnName("Quantity");
            builder.OwnsOne<MoneyValue>(own => own.Value, value => {
                value.Property(p => p.Currency).HasColumnName("Currency");
                value.Property(p => p.Value).HasColumnName("Value").HasColumnType("decimal(12,8)");
            });
        }
    }
}
