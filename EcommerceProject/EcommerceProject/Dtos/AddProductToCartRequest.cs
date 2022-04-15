namespace EcommerceProject.API.Dtos
{
    public class AddProductToCartRequest
    {
        public int CartId { get; init; }
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
