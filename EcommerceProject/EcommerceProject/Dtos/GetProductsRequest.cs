using EcommerceProject.Domain.SharedKermel;

namespace EcommerceProject.API.Dtos
{
    public class GetProductsRequest
    {
        public string Name { get; init; }
        public string TradeMark { get; init; }
        public string Origin { get; init; }
        public string Currency { get; init; }
        public decimal MaxValue { get; init; }
        public decimal MinValue { get; init; }
    }
}
