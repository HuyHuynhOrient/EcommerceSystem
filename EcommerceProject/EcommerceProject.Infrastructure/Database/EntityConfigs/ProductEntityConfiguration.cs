using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
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
    internal sealed class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(k => k.Id);

            builder.Property("Id").HasColumnName("ProductId");
            builder.Property("Name").HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property("ProductNumber").HasColumnName("ProductNumber").IsRequired();
            builder.Property("TradeMark").HasColumnName("TradeMark").HasMaxLength(100);
            builder.Property("Origin").HasColumnName("Origin").HasMaxLength(100);
            builder.Property("Discription").HasColumnName("Discription").HasColumnType("ntext");
            builder.OwnsOne<MoneyValue>(own => own.Price, price => {
                price.Property(p => p.Currency).HasColumnName("Currency");
                price.Property(p => p.Value).HasColumnName("Value");
            });
        }
    }
}
