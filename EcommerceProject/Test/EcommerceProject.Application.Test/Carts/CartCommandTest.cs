using EcommerceProject.Application.Commands.Carts.AddProductToCart;
using EcommerceProject.Application.Commands.Carts.ChangeProductQuantity;
using EcommerceProject.Application.Commands.Carts.PlaceOrder;
using EcommerceProject.Application.Commands.Carts.RemoveProductFromCart;
using EcommerceProject.Application.Test.Mock;
using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.AggregatesRoot.OrderAggregate;
using EcommerceProject.Domain.AggregatesRoot.ProductAggregate;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Application.Test.Carts
{
    public class CartCommandTest
    {
        private readonly Mock<ICartRepository> _mockCartRepository;
        private readonly Mock<ICartRepository> _mockNullCartRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IProductRepository> _mockNullProductRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly ChangeProductQuantityCommand _changeProductCommand;
        private readonly AddProductToCartCommand _addProductToCartCommand;
        private readonly RemoveProductFromCartCommand _removeProductFromCartCommand;
        private readonly PlaceOrderCommand _placeOrderCommand;

        public CartCommandTest()
        {
            _mockCartRepository = MockCartRepository.GetCartRepository();
            _mockProductRepository = MockProductRepository.GetProductRepository();
            _mockNullCartRepository = MockCartRepository.GetNullCartRepository();
            _mockNullProductRepository = MockProductRepository.GetNullProductRepository();
            _mockOrderRepository = MockOrderRepository.GetOrderRepository();
            var userId = Guid.NewGuid();
            var productId = 1;
            var carproductId = 1;
            var quantity = 4;
            var shippingAddress = "01 Nguyen Huu Tho, Da Nang, Viet Nam";
            var shippingPhoneNumber = "0000-000-000";
            _addProductToCartCommand = new AddProductToCartCommand()
            {
                ProductId = productId,
                Quantity = quantity,
                UserId = userId
            };
            _changeProductCommand = new ChangeProductQuantityCommand()
            {
                CartProductId = carproductId,
                ProductId = productId,
                Quantity = quantity,
                UserId = userId
            };
            _removeProductFromCartCommand = new RemoveProductFromCartCommand()
            {
                UserId = userId,
                CartProductId = carproductId
            };
            _placeOrderCommand = new PlaceOrderCommand()
            {
                UserId = userId,
                ShippingAddress = shippingAddress,
                ShippingPhoneNumber = shippingPhoneNumber
            };
        }

        [Fact]
        public async Task GetUserId_WhenAddingProductToCart_IsSuccessful()
        {
            var handler = new AddProductToCartCommandHandler(_mockCartRepository.Object, _mockProductRepository.Object);

            var result = await handler.Handle(_addProductToCartCommand, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(result.Response, _addProductToCartCommand.UserId);
        }

        [Fact]
        public async Task GetCommandResultError_WhenAddingProductToNotExistCart_ThenItReturnError()
        {
            var handler = new AddProductToCartCommandHandler(_mockNullCartRepository.Object, _mockProductRepository.Object);

            var result = await handler.Handle(_addProductToCartCommand, CancellationToken.None);

            string message = "Do not find a cart with customer id.";
            Assert.Equal(result.Message, message);
        }

        [Fact]
        public async Task GetCommandResultError_WhenAddingNotExistProductToCart_ThenItReturnError()
        {
            var handler = new AddProductToCartCommandHandler(_mockCartRepository.Object, _mockNullProductRepository.Object);

            var result = await handler.Handle(_addProductToCartCommand, CancellationToken.None);

            string message = "Your product is not exist.";
            Assert.Equal(result.Message, message);
        }

        [Fact]
        public async Task GetUserId_WhenChangingProductQuantity_IsSuccessful()
        {
            var handler = new ChangeProductQuantityCommandHandler(_mockCartRepository.Object, _mockProductRepository.Object);

            var result = await handler.Handle(_changeProductCommand, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(result.Response, _changeProductCommand.UserId);
        }

        [Fact]
        public async Task GetCommandResultError_WhenChangingProductQuantityToNotExistCart_ThenItReturnError()
        {
            var handler = new ChangeProductQuantityCommandHandler(_mockNullCartRepository.Object, _mockProductRepository.Object);

            var result = await handler.Handle(_changeProductCommand, CancellationToken.None);

            string message = "Do not find a cart with customer id.";
            Assert.Equal(result.Message, message);
        }

        [Fact]
        public async Task GetCommandResultError_WhenChaningNotExistProductId_ThenItReturnError()
        {
            var handler = new ChangeProductQuantityCommandHandler(_mockCartRepository.Object, _mockNullProductRepository.Object);

            var result = await handler.Handle(_changeProductCommand, CancellationToken.None);

            string message = "Your product is not exist.";
            Assert.Equal(result.Message, message);
        }

        [Fact]
        public async Task GetUserId_WhenRemovingProductFromCart_IsSuccessful()
        {
            var handler = new RemoveProductFromCartCommandHandler(_mockCartRepository.Object);

            var result = await handler.Handle(_removeProductFromCartCommand, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(result.Response, _removeProductFromCartCommand.UserId);
        }

        [Fact]
        public async Task GetCommandResultError_WhenRemovingProductFromCart_ThenItReturnError()
        {
            var handler = new RemoveProductFromCartCommandHandler(_mockNullCartRepository.Object);

            var result = await handler.Handle(_removeProductFromCartCommand, CancellationToken.None);

            string message = "Do not find a cart with customer id.";
            Assert.Equal(result.Message, message);
        }

        [Fact]
        public async Task GetSuccess_WhenPlacingOrderCommand_IsSuccessful()
        {
            var handler = new PlaceOrderCommandHandler(_mockCartRepository.Object, _mockOrderRepository.Object);

            var result = await handler.Handle(_placeOrderCommand, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetCommandResultError_WhenPlacingOrderFromNotExistCart_ThenItReturnError()
        {
            var handler = new PlaceOrderCommandHandler(_mockNullCartRepository.Object, _mockOrderRepository.Object);

            var result = await handler.Handle(_placeOrderCommand, CancellationToken.None);

            string message = "Do not find a cart with customer id.";
            Assert.Equal(result.Message, message);
        }
    }
}
