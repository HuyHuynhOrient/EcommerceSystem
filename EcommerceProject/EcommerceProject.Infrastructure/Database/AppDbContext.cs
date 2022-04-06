using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Orders;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.Database.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Database
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }   // Product aggregate
        public DbSet<Customer> Customers { get; set; } // Customer aggregate
        public DbSet<Order> Orders { get; set; } // Customer's Entity
        public DbSet<OrderProduct> OrderProducts { get; set; } // Customer's Entity
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
