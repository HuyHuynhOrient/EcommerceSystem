using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Carts.GetCartDetails
{
    public class GetCartDetailsQueryHandler : IQueryHandler<GetCartDetailsQuery, Cart>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public GetCartDetailsQueryHandler(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task<Cart> Handle(GetCartDetailsQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindOneAsync(query.UserId, cancellationToken);
            if (user == null) return null;

            return await _cartRepository.FindOneAsync(query.CartId, cancellationToken);
        }
    }
}
