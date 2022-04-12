using EcommerceProject.API.Dtos;
using EcommerceProject.Application.Commands.Carts.AddProductToCart;
using EcommerceProject.Application.Commands.Carts.ChangeProductQuantity;
using EcommerceProject.Application.Commands.Carts.PlaceOrder;
using EcommerceProject.Application.Commands.Carts.RemoveProductFromCart;
using EcommerceProject.Application.Queries.Carts.GetCartDetails;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Controllers
{
    [Route("api/customers/{customerId}/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public CartController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        [Route("{cartId}")]
        public async Task<IActionResult> GetCartDetails([FromRoute] int cartId
                                                , [FromRoute] Guid customerId
                                                , CancellationToken cancellationToken)
        {
            var query = new GetCartDetailsQuery 
            {
                CartId = cartId,
                CustomerId = customerId
            };
            var result = await _queryBus.SendAsync(query, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("{cartId}/products")]
        public async Task<IActionResult> AddProductToCart([FromRoute] int cartId
                            , [FromRoute] Guid customerId
                            , [FromBody] AddProductToCartRequest request
                            , CancellationToken cancellationToken)
        {
            var command = new AddProductToCartCommand
            {
                CustomerId = customerId,
                CartId = cartId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("{cartId}/products/{cartProductId}")]
        public async Task<IActionResult> ChangeProductQuantity([FromRoute] Guid customerId
                                                    , [FromRoute] int cartId
                                                    , [FromRoute] int cartProductId
                                                    , [FromBody] ChangeProductQuantityRequest request
                                                    , CancellationToken cancellationToken)
        {
            var command = new ChangeProductQuantityCommand
            {
                CustomerId = customerId,
                CartId = cartId,
                CartProductId = cartProductId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{cartId}/products/{cartProductId}")]
        public async Task<IActionResult> RemoveProductFromCart([FromRoute] Guid customerId
                            , [FromRoute] int cartId
                            , [FromRoute] int cartProductId
                            , CancellationToken cancellationToken)
        {
            var command = new RemoveProductFromCartCommand 
            { 
                CustomerId = customerId,
                CartId = cartId, 
                CartProductId = cartProductId 
            };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("{cartId}/place-order")]
        public async Task<IActionResult> PlaceOrder([FromRoute] Guid customerId
                            , [FromRoute] int cartId
                            , [FromBody] PlaceOrderRequest request
                            , CancellationToken cancellationToken)
        {
            var command = new PlaceOrderCommand
            {
                CustomerId = customerId,
                CartId = cartId,
                ShippingAddress = request.ShippingAddress,
                ShippingPhoneNumber = request.ShippingPhoneNumber
            };
            var result = await _commandBus.SendAsync(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
