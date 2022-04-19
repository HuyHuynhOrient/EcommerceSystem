using EcommerceProject.Application.Commands.Carts.AddProductToCart;
using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.AggregatesRoot.ProductAggregate;
using EcommerceProject.Domain.SeedWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Application.Test.Commands.Carts.AddProductToCart
{
    public class AddProductToCartCommandHandlerTest
    {
        private Mock<ICartRepository> mockCartRepository = new Mock<ICartRepository>();
        private Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
        private AddProductToCartCommand command = new AddProductToCartCommand()
        {
            ProductId = 1,
            Quantity = 1,
            UserId = Guid.NewGuid(),
        };

        [Fact]
        public async Task GivenACart_WhenAddingProductToCart_ThenItShouldBeSuccessful()
        {
            var cart = new Cart(command.UserId);
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(cart);
            var handler = new AddProductToCartCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Gi
    }
}
