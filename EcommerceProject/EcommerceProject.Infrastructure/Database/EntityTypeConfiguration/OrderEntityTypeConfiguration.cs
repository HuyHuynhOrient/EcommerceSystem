using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SharedKermel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityTypeConfiguration
{
    internal sealed class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.Property(p => p.Id).HasColumnName("OrderId").UseIdentityColumn();
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CustomerId).HasColumnName("CustomerId");
            builder.HasOne<Customer>().WithMany();
            builder.HasMany(p => p.OrderProducts).WithOne();

            builder.Property(p => p.CreateDate).HasColumnName("CreateDate");
            builder.Property(p => p.ShippingAddress).HasColumnName("ShippingAddress");
            builder.Property(p => p.ShippingPhoneNumber).HasColumnName("ShippingPhoneNumber");
            builder.Property(p => p.isRemoved).HasColumnName("IsRemoved").IsRequired();
            builder.Property(p => p.OrderStatus).HasColumnName("OrderStatus").HasConversion(new EnumToNumberConverter<OrderStatus, byte>());
            builder.OwnsOne<MoneyValue>(own => own.Value, value => {
                value.Property(p => p.Currency).HasColumnName("Currency");
                value.Property(p => p.Value).HasColumnName("Value").HasColumnType("decimal(12,8)");
            });
        }
    }
}
