using EcommerceProject.API.Dtos;
using EcommerceProject.Application.Commands.Carts.AddProductToCart;
using EcommerceProject.Application.Commands.Carts.ChangeProductQuantity;
using EcommerceProject.Application.Commands.Carts.PlaceOrder;
using EcommerceProject.Application.Commands.Carts.RemoveProductFromCart;
using EcommerceProject.Application.Queries.Carts.GetCartDetails;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Controllers
{
    [Route("api/carts")]
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
        public async Task<IActionResult> GetCartDetails([FromRoute] int cartId, CancellationToken cancellationToken)
        {
            var query = new GetCartDetailsQuery { CartId = cartId };
            var result = await _queryBus.SendAsync(query, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("{cartId}/cart-products")]
        public async Task<IActionResult> AddProductToCart([FromRoute] int cartId
                            ,[FromBody] AddProductToCartRequest request
                            ,CancellationToken cancellationToken)
        {
            var command = new AddProductToCartCommand
            {
                CartId = cartId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("{cartId}/cart-products/{cartProductId}")]
        public async Task<IActionResult> ChangeProductQuantity([FromRoute] int cartId
            , [FromRoute] int cartProductId
            , [FromBody] ChangeProductQuantityRequest request
            , CancellationToken cancellationToken)
        {
            var command = new ChangeProductQuantityCommand
            {
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
        [Route("{cartId}/cart-products/{cartProductId}")]
        public async Task<IActionResult> RemoveProductFromCart([FromRoute] int cartId
                            , [FromRoute] int cartProductId
                            , CancellationToken cancellationToken)
        {
            var command = new RemoveProductFromCartCommand 
            { 
                CartId = cartId, 
                CartProductId = cartProductId 
            };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("{cartId}/place-order")]
        public async Task<IActionResult> PlaceOrder([FromRoute] int cartId
                            , [FromBody] PlaceOrderRequest request
                            , CancellationToken cancellationToken)
        {
            var command = new PlaceOrderCommand
            {
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
