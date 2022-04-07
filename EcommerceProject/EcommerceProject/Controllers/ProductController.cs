using EcommerceProject.Application.Queries.Products;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public ProductController(IQueryBus queryBus, ICommandBus commandBus)
        {
            this._queryBus = queryBus;
            this._commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var query = new GetAllProductsQuery();
            var result = await _queryBus.SendAsync(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery { Id = productId };
            var result = await _queryBus.SendAsync(query, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
