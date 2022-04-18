using EcommerceProject.Domain.SharedKermel;

namespace EcommerceProject.API.Dtos
{
    public class CreateProductRequest
    {
        public string Name { get; init; }
        public decimal MoneyValue { get; init; }
        public string Currency { get; init; }
        public string TradeMark { get; init; }
        public string Origin { get; init; }
        public string Discription { get; init; }
    }
}
