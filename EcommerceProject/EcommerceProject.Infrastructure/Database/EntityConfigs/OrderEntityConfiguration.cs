using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Orders;
using EcommerceProject.Domain.SharedKermel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityConfigs
{
    internal sealed class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", SchemaName.Order);
            builder.HasKey(k => k.Id);
            builder.HasMany(o => o.OrderProducts).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Property("Id").HasColumnName("OrderId");
            builder.Property("CreateDate").HasColumnName("CreateDate").HasColumnType("date").IsRequired();
            builder.Property("ShippingAddress").HasColumnName("ShippingAddress").HasMaxLength(200).IsRequired();
            builder.Property("ShippingPhoneNumber").HasColumnName("ShippingPhoneNumber").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property("isRemoved").HasColumnName("IsRemoved").IsRequired();
            builder.Property("OrderStatus").HasColumnName("OrderStatus").HasConversion(new EnumToNumberConverter<OrderStatus, byte>());
            builder.OwnsOne<MoneyValue>(own => own.Value, value => {
                value.Property(p => p.Currency).HasColumnName("Currency");
                value.Property(p => p.Value).HasColumnName("Value");
            });
        }
    }
}
