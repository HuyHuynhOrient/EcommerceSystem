using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Carts.PlaceOrder
{
    public class PlaceOrderCommand : ICommand
    {
        public int CartId { get; init; }
        public string ShippingAddress { get; init; }
        public string ShippingPhoneNumber { get; init; }
    }
}
