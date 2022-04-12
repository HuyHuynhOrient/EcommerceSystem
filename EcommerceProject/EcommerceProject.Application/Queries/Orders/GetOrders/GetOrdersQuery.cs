using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Orders.GetOrders
{
    public class GetOrdersQuery : IQuery<IEnumerable<Order>>
    {
    }
}
