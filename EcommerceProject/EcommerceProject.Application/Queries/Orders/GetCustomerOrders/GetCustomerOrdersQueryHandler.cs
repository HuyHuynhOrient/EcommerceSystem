using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Orders.GetOrders
{
    public class GetCustomerOrdersQueryHandler : IQueryHandler<GetCustomerOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _customerRepository;

        public GetCustomerOrdersQueryHandler(IOrderRepository orderRepository, IUserRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetCustomerOrdersQuery query, CancellationToken cancellationToken)
        {
            var cusomter = await _customerRepository.FindOneAsync(query.CustomerId, cancellationToken);
            if (cusomter == null) return null;

            var spec = new SpecificationBase<Order>(x => x.UserId == query.CustomerId);
            
            return await _orderRepository.FindAllAsync(spec, cancellationToken);
        }
    }
}
