using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.RemoveProductFromCart
{
    public class RemoveProductFromCartCommandHandler : ICommandHandler<RemoveProductFromCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _customerRepository;

        public RemoveProductFromCartCommandHandler(ICartRepository cartRepository, IUserRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CommandResult<int>> Handle(RemoveProductFromCartCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindOneAsync(command.CustomerId, cancellationToken);
            if (customer == null) return CommandResult<int>.Error("You do not have permission to execute this command.");

            var cart = await _cartRepository.FindOneAsync(command.CartId, cancellationToken);
            if (cart == null) return CommandResult<int>.Error("Your cart is not exist.");
            
            cart.RemoveCartProduct(command.CartProductId);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<int>.Success(command.CartId);
        }
    }
}
