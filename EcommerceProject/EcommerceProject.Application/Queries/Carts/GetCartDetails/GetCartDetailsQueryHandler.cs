using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Carts.GetCartDetails
{
    public class GetCartDetailsQueryHandler : IQueryHandler<GetCartDetailsQuery, Cart>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartDetailsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> Handle(GetCartDetailsQuery query, CancellationToken cancellationToken)
        {
            return await _cartRepository.FindOneAsync(query.CartId, cancellationToken);
        }
    }
}
