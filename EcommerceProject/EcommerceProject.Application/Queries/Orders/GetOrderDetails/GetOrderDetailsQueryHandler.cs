using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
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
        private readonly ICustomerRepository _customerRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Order> Handle(GetOrderDetailsQuery query, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindOneAsync(query.CustomerId, cancellationToken);
            if (customer == null) return null;

            return await _orderRepository.FindOneAsync(query.OrderId, cancellationToken);
        }
    }
}
