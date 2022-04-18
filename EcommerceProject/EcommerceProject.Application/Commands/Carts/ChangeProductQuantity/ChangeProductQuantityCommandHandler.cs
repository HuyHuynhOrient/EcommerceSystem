using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.ChangeProductQuantity
{
    public class ChangeProductQuantityCommandHandler : ICommandHandler<ChangeProductQuantityCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public ChangeProductQuantityCommandHandler(ICartRepository cartRepository, IUserRepository userRepository,
                              IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task<CommandResult<int>> Handle(ChangeProductQuantityCommand command, CancellationToken cancellationToken)
        {
            var spec = new SpecificationBase<Cart>(x => x.UserId == command.UserId);
            var cart = await _cartRepository.FindOneAsync(spec, cancellationToken);
            if (cart == null) return CommandResult<int>.Error("Do not find a cart with customer id.");

            var product = await _productRepository.FindOneAsync(command.ProductId, cancellationToken);
            if (product == null) return CommandResult<int>.Error("Your product is not exist.");

            cart.ChangeCartProductQuantity(command.CartProductId, command.Quantity);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<int>.Success(product.Id);
        }
    }
}
