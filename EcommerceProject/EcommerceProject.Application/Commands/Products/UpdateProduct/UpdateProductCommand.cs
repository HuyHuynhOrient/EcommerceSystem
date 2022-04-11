using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SharedKermel;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommand : ICommand<int>
    {
        public int ProductId { get; set; }
        public string Name { get; init; }
        public MoneyValue Price { get; init; }
        public string TradeMark { get; init; }
        public string Origin { get; init; }
        public string Discription { get; init; }
    }
}
