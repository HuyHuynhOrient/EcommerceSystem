namespace EcommerceProject.API.Dtos
{
    public class PlaceOrderRequest
    {
        public int CartId { get; init; }
        public string ShippingAddress { get; init; }
        public string ShippingPhoneNumber { get; init; }
    }
}
