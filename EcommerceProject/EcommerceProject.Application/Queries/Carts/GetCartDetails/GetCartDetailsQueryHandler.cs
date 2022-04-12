using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Carts.GetCartDetails
{
    public class GetCartDetailsQueryHandler : IQueryHandler<GetCartDetailsQuery, Cart>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;

        public GetCartDetailsQueryHandler(ICartRepository cartRepository, ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Cart> Handle(GetCartDetailsQuery query, CancellationToken cancellationToken)
        {
            var cusomter = await _customerRepository.FindOneAsync(query.CustomerId, cancellationToken);
            if (cusomter == null) return null;

            return await _cartRepository.FindOneAsync(query.CartId, cancellationToken);
        }
    }
}
