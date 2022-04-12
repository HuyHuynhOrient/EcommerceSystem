using EcommerceProject.API.Dtos;
using EcommerceProject.Application.Commands.Orders.ChangeOrderStatus;
using EcommerceProject.Application.Queries.Orders.GetOrderDetails;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        
        public OrderController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetOrders()
        
        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderDetails([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsQuery { OrderId = orderId };
            var result = await _queryBus.SendAsync(query, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("{orderId}/change-order-status")]
        public async Task<IActionResult> ChangeOrderStatus([FromRoute] int orderId, [FromBody] ChangeOrderStatusRequest request, 
                                CancellationToken cancellationToken)
        {
            var command = new ChangeOrderStatusCommand { OrderId = orderId, OrderStatus = request.OrderStatus };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
