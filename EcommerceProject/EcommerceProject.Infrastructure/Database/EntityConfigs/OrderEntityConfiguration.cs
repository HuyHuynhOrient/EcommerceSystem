using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityConfigs
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Value).HasColumnName("Value");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.ShippingAddress).HasColumnName("ShippingAddress");
            builder.Property(x => x.ShippingPhoneNumber).HasColumnName("ShippingPhoneNumber");
            builder.Property(x => x.OrderStatus).HasColumnName("OrderStatus");
            builder.Property(x => x.isRemoved).HasColumnName("IsRemoved");
        }
    }
}
