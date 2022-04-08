using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Products.GetProductById
{
    public class GetProductDetailsQueryHandler : IQueryHandler<GetProductDetailsQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.FindOneAsync(request.Id, cancellationToken);
        }
    }
}
