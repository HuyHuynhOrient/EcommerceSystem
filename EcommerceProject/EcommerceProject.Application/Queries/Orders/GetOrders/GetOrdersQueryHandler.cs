using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Orders.GetOrders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.FindAllAsync(null, cancellationToken);

            //Return only data of customer
            return orders;
        }
    }
}
