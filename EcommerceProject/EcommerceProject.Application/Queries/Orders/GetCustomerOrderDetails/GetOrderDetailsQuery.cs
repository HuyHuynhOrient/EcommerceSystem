using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Orders.GetOrderById
{
    internal class GetOrderDetailsQuery : IQuery<Order>
    {
        public int Id { get; init; }
    }
}
