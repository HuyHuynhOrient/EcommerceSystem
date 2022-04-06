using System.Reflection;
using EcommerceProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
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

            return services;
        }
    }
}

