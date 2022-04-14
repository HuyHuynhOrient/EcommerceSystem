using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.ChangeProductQuantity
{
    public class ChangeProductQuantityCommand : ICommand<int>
    {
        public Guid UserId { get; init; }
        public int CartId { get; init; }
        public int CartProductId { get; init; }
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
