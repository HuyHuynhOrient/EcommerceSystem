namespace EcommerceProject.API.Dtos
{
    public class RemoveProductFromCartRequest
    {
        public int CartId { get; init; }
        public int CartProductId { get; init; }    
    }
}