using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Orders.GetOrderById
{
    internal class GetOrderDetailsHandler : IQueryHandler<GetOrderDetailsQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsHandler(IOrderRepository orderRepository)
        {
           _orderRepository = orderRepository;
        }
        public Task<Order> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            return _orderRepository.FindOneAsync(request.Id, cancellationToken);
        }
    }
}
