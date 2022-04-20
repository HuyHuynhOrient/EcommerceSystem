using EcommerceProject.Application.Commands.Carts.ChangeProductQuantity;
using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.AggregatesRoot.ProductAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Application.Test.Commands.Carts.ChangeProductQuantity
{
    public class ChangeProductQuantityCommandHandlerTest
    {
        private readonly Mock<ICartRepository> mockCartRepository;
        private readonly Mock<IProductRepository> mockProductRepository;
        private readonly ChangeProductQuantityCommand command = new ChangeProductQuantityCommand()
        {
            UserId = Guid.NewGuid(),
            ProductId = 1,
            CartProductId = 1,
            Quantity = 3,
        };

        [Fact]
        public async Task GivenACart_WhenChangingProductQuantityToCart_ThenItShouldBeSuccess()
        {
            var product = new Product("Macbook", MoneyValue.Of(100, "USA"), "Apple", "China", "This is a macbook.");
            product.Id = command.ProductId;
            var cartProduct = new CartProduct(command.ProductId, command.Quantity, product.Price);
            var cart = new Cart(command.UserId);
            cart.AddCartProduct(cartProduct);

            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(cart);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), default(CancellationToken)));
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(product);
            var handler = new ChangeProductQuantityCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GivenACart_WhenChangingProductQuantityToNotExistCart_ThenItShouldBeError()
        {
            var product = new Product("Macbook", MoneyValue.Of(100, "USA"), "Apple", "China", "This is a macbook.");
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(() => null);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), default(CancellationToken)));
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(product);
            var handler = new ChangeProductQuantityCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            string messsage = "Do not find a cart with customer id.";
            Assert.Equal(messsage, result.Message);
        }

        [Fact]
        public async Task GivenACart_WhenChagingProductQuantityFromCartButProductIdIsWrong_ThenItShouldBeError()
        {
            var cart = new Cart(command.UserId);
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(cart);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), default(CancellationToken)));
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(() => null);
            var handler = new ChangeProductQuantityCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            string message = "Your product is not exist.";
            Assert.Equal(message, result.Message);
        }
    }
}
