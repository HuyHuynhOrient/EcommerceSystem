using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Domain.Repository
{
    internal class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
        Task<Order> IBaseRepository<Order, int>.FindOneAsync(int id, CancellationToken cancellationToken)
        {
            var spec = new SpecificationBase<Order>(x => x.Id == id);
            spec.Includes.Add(x => x.OrderProducts);
            return FindOneAsync(spec, cancellationToken);
        }
    }
}
