using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Orders.GetOrders
{
    public class GetCustomerOrdersQuery : IQuery<IEnumerable<Order>>
    {
        public Guid CustomerId { get; init; }
    }
}
