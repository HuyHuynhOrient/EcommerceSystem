using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.RemoveProductFromCart
{
    public class RemoveProductFromCartCommandHandler : ICommandHandler<RemoveProductFromCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public RemoveProductFromCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task<CommandResult<int>> Handle(RemoveProductFromCartCommand command, CancellationToken cancellationToken)
        {
            var customer = await _userRepository.FindOneAsync(command.CustomerId, cancellationToken);
            if (customer == null || customer.UserRole != UserRole.Customer) 
                return CommandResult<int>.Error("You do not have permission to execute this command.");

            var cart = await _cartRepository.FindOneAsync(command.CartId, cancellationToken);
            if (cart == null) return CommandResult<int>.Error("Your cart is not exist.");
            
            cart.RemoveCartProduct(command.CartProductId);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<int>.Success(command.CartId);
        }
    }
}
