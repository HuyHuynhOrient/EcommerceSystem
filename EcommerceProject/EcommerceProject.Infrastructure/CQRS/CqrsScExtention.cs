using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.CQRS
{
    public static class CqrsScExtention
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<ICommandBus, CommandBus>();

            return services;
        }
    }
}
