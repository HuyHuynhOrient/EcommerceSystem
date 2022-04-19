using EcommerceProject.Application.Queries.Carts.GetCartDetails;
using EcommerceProject.Application.Test.Mock;
using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.AggregatesRoot.UserAggregate;
using EcommerceProject.Domain.SharedKermel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Application.Test.Carts
{
    public class CartQueryTest
    {
        private readonly Mock<ICartRepository> _mockCartRepository;
        private readonly Mock<ICartRepository> _mockNullCartRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IUserRepository> _moclNullUserRepository;
        private readonly GetCartDetailsQuery _getCartDetailsQuery;
        
        public CartQueryTest()
        {
            _mockCartRepository = MockCartRepository.GetCartRepository();
            _mockNullCartRepository = MockCartRepository.GetNullCartRepository();
            _mockUserRepository = MockUserRepository.GetUserRepository();
            _moclNullUserRepository = MockUserRepository.GetNullUserRepository();
            var userId = Guid.NewGuid();
            _getCartDetailsQuery = new GetCartDetailsQuery()
            {
                UserId = userId
            };
        }

        [Fact]
        public async Task GetCartDetails_WhenQueringCartDetailsByUserId_ThenItShouldReturnCart()
        {
            var cartProduct = new CartProduct(1, 2, MoneyValue.Of(100, "USA"));
            cartProduct.Id = 1;
            var cart = new Cart(Guid.NewGuid());
            cart.AddCartProduct(cartProduct);
            cart.Id = 1;
            var handler = new GetCartDetailsQueryHandler(_mockCartRepository.Object, _mockUserRepository.Object);

            var result = await handler.Handle(_getCartDetailsQuery, CancellationToken.None);

            Assert.Equal(cart.Id, result.Id);
            Assert.Equal(cart.Value, result.Value);
            Assert.Equal(cart.CartProducts[0].Id, result.CartProducts[0].Id);
            Assert.Equal(cart.CartProducts[0].ProductId, result.CartProducts[0].ProductId);
            Assert.Equal(cart.CartProducts[0].Quantity, result.CartProducts[0].Quantity);
        }

        [Fact]
        public async Task GetCartDetails_WhenQueringCartDetailsByUserIdButCartNotExist_ThenItShouldBeThrowException()
        {
            var handler = new GetCartDetailsQueryHandler(_mockNullCartRepository.Object, _mockUserRepository.Object);

            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(_getCartDetailsQuery, CancellationToken.None));

            string message = "Each customer must has an cart. Something is broken.";
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task GetNull_WhenQueringCartDetailsByUserIdButUserNotExist_ThenItShouldBeReturnNull()
        {
            var handler = new GetCartDetailsQueryHandler(_mockCartRepository.Object, _moclNullUserRepository.Object);

            var result = await handler.Handle(_getCartDetailsQuery, CancellationToken.None);
            
            Assert.Null(result);
        }
    }
}
