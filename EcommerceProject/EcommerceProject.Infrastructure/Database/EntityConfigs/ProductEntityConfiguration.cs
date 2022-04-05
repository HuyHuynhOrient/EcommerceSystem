using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database.EntityConfigs
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            // ColumPrice
            builder.Property(x => x.ProductNumber).HasColumnName("ProductNumber");
            builder.Property(x => x.TradeMark).HasColumnName("TradeMark");
            builder.Property(x => x.Origin).HasColumnName("Origin");
            builder.Property(x => x.Discription).HasColumnName("Discription");
        }
    }
}
