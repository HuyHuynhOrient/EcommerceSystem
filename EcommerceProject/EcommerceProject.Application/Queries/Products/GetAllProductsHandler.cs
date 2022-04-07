using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Products
{
    public class GetAllProductsHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.FindAllAsync(null, cancellationToken);
        }
    }
}
