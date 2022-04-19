using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using Moq;
using System;
using System.Threading;

namespace EcommerceProject.Application.Test.Mock
{
    public static class MockCartRepository
    {
        public static Mock<ICartRepository> GetCartRepository()
        {
            var userId = Guid.NewGuid();
            var productId = 1;
            var price = MoneyValue.Of(100, "USA");
            var carproductId = 1;
            var quantity = 2;
            var cartProduct = new CartProduct(productId, quantity, price);
            cartProduct.Id = carproductId;
            var cart = new Cart(userId);
            cart.AddCartProduct(cartProduct);
            cart.Id = 1;

            var mockCartRepository = new Mock<ICartRepository>();
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), CancellationToken.None))
                                .ReturnsAsync(cart);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), CancellationToken.None));

            return mockCartRepository;
        }

        public static Mock<ICartRepository> GetNullCartRepository()
        {
            var mockCartRepository = new Mock<ICartRepository>();
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), CancellationToken.None))
                                .ReturnsAsync(() => null);

            return mockCartRepository;
        }
    }
}
