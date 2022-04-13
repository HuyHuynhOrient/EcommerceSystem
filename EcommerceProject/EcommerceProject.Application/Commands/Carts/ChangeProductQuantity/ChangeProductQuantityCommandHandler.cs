using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
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
            var customer = await _userRepository.FindOneAsync(command.CustomerId, cancellationToken);
            if (customer == null || customer.UserRole != UserRole.Customer) return CommandResult<int>.Error("You do not have permission to execute this command.");

            var cart = await _cartRepository.FindOneAsync(command.CartId, cancellationToken);
            if (cart == null) return CommandResult<int>.Error("Your cart is not exist.");
         
            var product = await _productRepository.FindOneAsync(command.ProductId, cancellationToken);
            if (product == null) return CommandResult<int>.Error("Your product is not exist.");

            cart.ChangeCartProductQuantity(command.CartProductId, command.Quantity, command.Quantity * product.Price);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<int>.Success(product.Id);
        }
    }
}
