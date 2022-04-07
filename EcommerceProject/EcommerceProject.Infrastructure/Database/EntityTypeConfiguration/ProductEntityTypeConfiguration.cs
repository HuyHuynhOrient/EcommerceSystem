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
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(p => p.TradeMark).HasColumnName("TradeMark").HasMaxLength(100);
            builder.Property(p => p.Origin).HasColumnName("Origin").HasMaxLength(100);
            builder.Property(p => p.Discription).HasColumnName("Discription").HasColumnType("ntext");
            builder.OwnsOne<MoneyValue>(own => own.Price, price => {
                price.Property(p => p.Currency).HasColumnName("Currency").HasColumnType("nvarchar(30)").IsRequired();
                price.Property(p => p.Value).HasColumnName("Value").HasColumnType("decimal(18,2)").IsRequired();
            });
        }
    }
}
