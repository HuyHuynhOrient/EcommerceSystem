using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Products
{
    public class GetAllProductsQuery : IQuery<IEnumerable<Product>>
    {
    }
}
