using EcommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.EF
{
    public class EcommerceSystemContext : DbContext
    {
        public EcommerceSystemContext(DbContextOptions<EcommerceSystemContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductSubcategoryEntity> ProductSubcategories { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        //Add-Migration NewMigration -Project EcommerceSystem.DAL

        private const string connectionString = @"Server=DD-HUYHDQ;Database=EcommerceSystems;Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(connectionString);
        }
    }
}
