using EcommerceProject.Application.Commands.Products.CreateProduct;
using EcommerceProject.Application.Commands.Products.DeleteProduct;
using EcommerceProject.Application.Commands.Products.UpdateProduct;
using EcommerceProject.Application.Queries.Products.GetProductById;
using EcommerceProject.Application.Queries.Products.GetProducts;
using EcommerceProject.Domain.SharedKermel;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceProject.Infrastructure.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Controllers
{
    [Route("api/products")]
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
            var query = new GetProductsQuery();
            var result = await _queryBus.SendAsync(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductDetails([FromRoute] int productId, CancellationToken cancellationToken)
        {
            var query = new GetProductDetailsQuery { Id = productId };
            var result = await _queryBus.SendAsync(query, cancellationToken);
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] string name, MoneyValue price, string tradeMark, string origin, string discription, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand 
            { 
                Name = name, 
                Price = price, 
                TradeMark = tradeMark, 
                Origin = origin, 
                Discription = discription 
            };
            var result = await _commandBus.SendAsync(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] int productId, string name, MoneyValue price, string tradeMark, string origin, string discription, CancellationToken cancellationToken)
        {
            var command = new UpdateProductCommand
            {
                ProductId = productId,
                Name = name,
                Price = price,
                TradeMark = tradeMark,
                Origin = origin,
                Discription = discription
            };
            var result = await _commandBus.SendAsync(command, cancellationToken);
            return Ok(result);
                
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand { Id = productId };
            var result = await _commandBus.SendAsync(command, cancellationToken);
            return Ok(result);
        }
    }
}
