﻿using EcommerceProject.Application.Commands.Carts.AddProductToCart;
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
        public async Task GivenACart_WhenAddingProductToCart_ThenItShouldBeReturnSuccess()
        {
            var cart = new Cart(command.UserId);
            var product = new Product("Macbook", MoneyValue.Of(100, "USA"), "VietNam", "VietNam", "This is a macbook.");
            product.Id = command.ProductId;
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(cart);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), default(CancellationToken)));
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(product);
            var handler = new AddProductToCartCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GivenACart_WhenAddingProductToNotExistCart_ThenItShouldBeReturnError()
        {
            var product = new Product("Macbook", MoneyValue.Of(100, "USA"), "VietNam", "VietNam", "This is a macbook.");
            product.Id = command.ProductId;
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(() => null);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), default(CancellationToken)));
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(product);
            var handler = new AddProductToCartCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            string message = "Do not find a cart with customer id.";
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async Task GivenACart_WhenAddingNotExistProductToCart_ThenItShouldBeReturnErrror()
        {
            var cart = new Cart(command.UserId);
            mockCartRepository.Setup(p => p.FindOneAsync(It.IsAny<SpecificationBase<Cart>>(), default(CancellationToken))).ReturnsAsync(cart);
            mockCartRepository.Setup(p => p.SaveAsync(It.IsAny<Cart>(), default(CancellationToken)));
            mockProductRepository.Setup(p => p.FindOneAsync(It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(() => null);
            var handler = new AddProductToCartCommandHandler(mockCartRepository.Object, mockProductRepository.Object);

            var result = await handler.Handle(command, default(CancellationToken));

            string message = "Your product is not exist.";
            Assert.Equal(message, result.Message);
        }
    }
}
