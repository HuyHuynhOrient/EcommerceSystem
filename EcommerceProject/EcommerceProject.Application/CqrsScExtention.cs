using EcommerceProject.Infrastructure.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application
{
    public static class CqrsScExtention
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCqrs(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
