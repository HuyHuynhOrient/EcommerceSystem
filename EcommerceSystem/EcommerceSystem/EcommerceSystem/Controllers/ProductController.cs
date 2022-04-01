using EcommerceSystem.BAL.Interfaces;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetProductsList()
        {
            return _productService.GetProductsList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductbyID(int id)
        {
            var product = _productService.GetProductbyID(id);
            if(product == null)
            {
                return NotFound("Invalid ID");
            }
            return Ok(product);
        }

        [HttpPost]
        public bool CreateProduct(Product request)
        {
            return _productService.CreateProduct(request);
        }

        [HttpPut]
        public bool EditProduct(Product request)
        {
            return _productService.UpdateProduct(request);
        }

        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}
