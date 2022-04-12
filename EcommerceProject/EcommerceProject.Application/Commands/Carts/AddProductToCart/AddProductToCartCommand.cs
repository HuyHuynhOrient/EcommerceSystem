using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.AddProductToCart
{
    public class AddProductToCartCommand : ICommand<int>
    {
        public Guid CustomerId { get; init; }
        public int CartId { get; init; }
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
