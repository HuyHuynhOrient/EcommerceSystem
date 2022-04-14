using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Orders.GetOrderDetails
{
    public class GetOrderDetailsQuery : IQuery<Order>
    {
        public int OrderId { get; init; }
        public Guid UserId { get; init; }
    }
}
