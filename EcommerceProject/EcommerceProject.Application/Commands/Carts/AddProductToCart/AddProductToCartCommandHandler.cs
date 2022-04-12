using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.AddProductToCart
{
    public class AddProductToCartCommandHandler : ICommandHandler<AddProductToCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public AddProductToCartCommandHandler(ICartRepository cartRepository, ICustomerRepository customerRepository,
                                IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<CommandResult<int>> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.FindOneAsync(command.CartId, cancellationToken);
            if (cart == null) return CommandResult<int>.Error("Your cart is not exist.");
           
            var product = await _productRepository.FindOneAsync(command.ProductId, cancellationToken);
            if (product == null) return CommandResult<int>.Error("Your product is not exist.");

            cart.AddCartProduct(command.ProductId, command.Quantity, command.Quantity * product.Price);
            await _cartRepository.SaveAsync(cart, cancellationToken);

            return CommandResult<int>.Success(product.Id);
        }
    }
}
