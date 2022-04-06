using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities;
using EcommerceProject.Domain.SharedKermel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityConfigs
{
    internal sealed class OrderProductEntityConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct", SchemaName.Order);
            builder.HasKey(k => k.Id);
            builder.HasOne(b => b.Product).WithMany();

            builder.Property<Guid>("OrderId").HasColumnName("OrderId");
            builder.OwnsOne<MoneyValue>(own => own.Value, value => {
                value.Property(p => p.Currency).HasColumnName("Currency");
                value.Property(p => p.Value).HasColumnName("Value");
            });
        }
    }
}
