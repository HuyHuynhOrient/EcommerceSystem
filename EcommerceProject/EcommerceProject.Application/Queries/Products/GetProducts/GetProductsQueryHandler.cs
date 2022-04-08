﻿using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;

namespace EcommerceProject.Application.Queries.Products.GetProducts
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.FindAllAsync(null, cancellationToken);
        }
    }
}
