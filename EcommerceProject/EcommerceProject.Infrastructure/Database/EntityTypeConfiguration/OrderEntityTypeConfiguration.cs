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
            builder.HasKey(k => k.Id);
            builder.HasOne<Customer>().WithMany();

            builder.Property(p => p.Id).HasColumnName("OrderId").UseIdentityColumn();
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate").HasColumnType("date").IsRequired();
            builder.Property(p => p.ShippingAddress).HasColumnName("ShippingAddress").HasMaxLength(200).IsRequired();
            builder.Property(p => p.ShippingPhoneNumber).HasColumnName("ShippingPhoneNumber").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.isRemoved).HasColumnName("IsRemoved").IsRequired();
            builder.Property(p => p.OrderStatus).HasColumnName("OrderStatus").HasConversion(new EnumToNumberConverter<OrderStatus, byte>());
            builder.OwnsOne<MoneyValue>(own => own.Value, value => {
                value.Property(p => p.Currency).HasColumnName("Currency").HasColumnType("nvarchar(30)").IsRequired();
                value.Property(p => p.Value).HasColumnName("Value").HasColumnType("decimal(18,2)").IsRequired();
            });
            builder.OwnsMany<OrderProduct>(own => own.OrderProducts, od => {
                od.WithOwner().HasForeignKey("OrderId");

                od.ToTable("OrderProduct");
                od.HasKey(k => k.Id);
                od.HasOne<Product>().WithMany();

                od.Property(p => p.Id).HasColumnName("OrderProductId");
                od.Property<int>("OrderId").HasColumnName("OrderId").IsRequired();
                od.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired();
                od.Property(p => p.Quantity).HasColumnName("Quantity").IsRequired();
                od.OwnsOne<MoneyValue>(own => own.Value, value => {
                    value.Property(p => p.Currency).HasColumnName("Currency").HasColumnType("nvarchar(30)").IsRequired();
                    value.Property(p => p.Value).HasColumnName("Value").HasColumnType("decimal(18,2)").IsRequired();
                });

                od.HasIndex("OrderId", "ProductId").IsUnique();
            });
        }
    }
}
