using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Orders.GetOrderDetails
{
    public class GetOrderDetailsQuery : IQuery<Order>
    {
        public int OrderId { get; init; }
    }
}
