using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.ChangeProductQuantity
{
    public class ChangeProductQuantityCommandHandler : ICommandHandler<ChangeProductQuantityCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public ChangeProductQuantityCommandHandler(ICartRepository cartRepository, ICustomerRepository customerRepository,
                              IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<CommandResult<int>> Handle(ChangeProductQuantityCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindOneAsync(command.CustomerId, cancellationToken);
            if (customer == null) return CommandResult<int>.Error("You do not have permission to execute this command.");

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
