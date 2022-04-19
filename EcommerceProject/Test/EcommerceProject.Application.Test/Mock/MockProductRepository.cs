using EcommerceProject.Domain.AggregatesRoot.ProductAggregate;
using EcommerceProject.Domain.SharedKermel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Test.Mock
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var productId = 1;
            var product = new Product("Product 1", MoneyValue.Of(100, "USA"), "VietNam", "VietNam", "This is a product.");
            product.Id = productId;

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), CancellationToken.None))
                                   .ReturnsAsync(product);

            return mockProductRepository;
        }

        public static Mock<IProductRepository> GetNullProductRepository()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), CancellationToken.None))
                                    .ReturnsAsync(() => null);

            return mockProductRepository;
        }
    }
}
