using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Domain.SeedWork;
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

            var spec = new SpecificationBase<Cart>(x => x.UserId == query.UserId);
            var cart = await _cartRepository.FindOneAsync(spec, cancellationToken);
            if (cart is null) throw new Exception("Each customer must has an cart. Something is broken.");

            return cart;
        }
    }
}
