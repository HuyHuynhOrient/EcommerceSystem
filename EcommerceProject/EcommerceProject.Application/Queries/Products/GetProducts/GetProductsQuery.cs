using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Products.GetProducts
{
    public class GetProductsQuery : IQuery<IEnumerable<Product>>
    {
    }
}
