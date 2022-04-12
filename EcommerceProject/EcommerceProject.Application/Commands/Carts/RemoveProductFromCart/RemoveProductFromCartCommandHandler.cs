using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.RemoveProductFromCart
{
    public class RemoveProductFromCartCommandHandler : ICommandHandler<RemoveProductFromCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;

        public RemoveProductFromCartCommandHandler(ICartRepository cartRepository, ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CommandResult<int>> Handle(RemoveProductFromCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.FindOneAsync(command.CartId, cancellationToken);
            if (cart == null) return CommandResult<int>.Error("Your cart is not exist.");
            
            cart.RemoveCartProduct(command.CartProductId);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<int>.Success(command.CartId);
        }
    }
}
