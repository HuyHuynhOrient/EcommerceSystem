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
    internal sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("ProductId").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.TradeMark).HasColumnName("TradeMark");
            builder.Property(p => p.Origin).HasColumnName("Origin");
            builder.Property(p => p.Discription).HasColumnName("Discription");
            builder.OwnsOne<MoneyValue>(own => own.Price, price => {
                price.Property(p => p.Currency).HasColumnName("Currency");
                price.Property(p => p.Value).HasColumnName("Value").HasColumnType("decimal(12,8)");
            });
        }
    }
}
