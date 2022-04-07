using System.Reflection;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Infrastructure.Database;
using EcommerceProject.Infrastructure.Domain;
using EcommerceProject.Infrastructure.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetProject.Infrastructure.Domain
{
    public static class DomainScExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                var connection = configuration.GetSection("Database:ConnectionString").Value;
                options.UseSqlServer(connection,
                   x =>
                   {
                       x.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                   });
            });
            services.AddScoped<IUnitOfWork>(sp => new UnitOfWork((sp.GetRequiredService<AppDbContext>())));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}

