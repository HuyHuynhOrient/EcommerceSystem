using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Products
{
    public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.FindOneAsync(request.Id, cancellationToken);
        }
    }
}
