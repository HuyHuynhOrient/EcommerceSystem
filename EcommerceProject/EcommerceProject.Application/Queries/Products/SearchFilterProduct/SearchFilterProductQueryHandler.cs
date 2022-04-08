using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Products.SearchFilterProduct
{
    internal class SearchFilterProductQueryHandler : IQueryHandler<SearchFilterProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public SearchFilterProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(SearchFilterProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FindAllAsync(null, cancellationToken);

            //var searchProducts = from product in products
            //                     where product.Name == request.Name || product.Name is null
            //                     where product.Price == request.Price || product.Price is null
            //                     where product.TradeMark == request.TradeMark || product.TradeMark is null
            //                     where product.Origin == request.Origin || product.Origin is null
            //                     where product.Discription == request.Discription || product.Discription is null
            //                     select product;
            //return searchProducts;
            return products;
            // Normaly, Search function is inside the Select all function 
        }
    }
}
