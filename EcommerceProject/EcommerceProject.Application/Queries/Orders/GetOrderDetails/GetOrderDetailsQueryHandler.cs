using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Orders.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IQueryHandler<GetOrderDetailsQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderDetailsQuery command, CancellationToken cancellationToken)
        {
            return await _orderRepository.FindOneAsync(command.OrderId, cancellationToken);
        }
    }
}
