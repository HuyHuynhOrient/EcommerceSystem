namespace EcommerceProject.API.Dtos
{
    public class ChangeProductQuantityRequest
    {
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
