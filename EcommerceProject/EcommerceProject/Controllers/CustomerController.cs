using EcommerceProject.API.Dtos;
using EcommerceProject.Application.Commands.Customers.AuthenticateCustomer;
using EcommerceProject.Application.Commands.Customers.RegisterCustomer;
using EcommerceProject.Application.Queries.Customers.GetCustomers;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public CustomerController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var query = new GetCustomersQuery();
            var result = await _queryBus.SendAsync(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request, CancellationToken cancellationToken)
         {
            var command = new RegisterCustomerCommand { Name = request.Name, UserName = request.UserName, Email = request.Email , Password = request.Password};
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (!result.IsSuccess) return BadRequest();

            return Ok(new { customerId = result.Response.UserId, cartId = result.Response.CartId });
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var command = new AuthenticateCommand
            {
                Password = request.Password,
                UserName = request.UserName,
                RememberMe = request.RememberMe
            };
            var result = await _commandBus.SendAsyns(command, cancellationToken);
            if (!result.IsSuccess) return BadRequest();

            return Ok(new { token = result.Response });
        }
    }
}
