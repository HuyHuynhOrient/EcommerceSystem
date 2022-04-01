using EcommerceSystem.BAL.Interfaces;
using EcommerceSystem.Domain;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSubcategoryController : ControllerBase
    {
        private readonly IProductSubcategoryService _productSubcategoryService;
        public ProductSubcategoryController(IProductSubcategoryService productSubcategoryService)
        {
            _productSubcategoryService = productSubcategoryService;
        }

        [HttpGet]
        public List<ProductSubcategory> GetProductSubcategoriesList()
        {
            return _productSubcategoryService.GetProductSubcategoriesList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductSubcategory> GetProductSubcategory(int id)
        {
            var productSubcategory = _productSubcategoryService.GetProductSubcategorybyID(id);
            if(productSubcategory == null)
            {
                return NotFound("Invalid ID");
            }
            return Ok(productSubcategory);
        }

        [HttpPost]
        public bool CreateProductSubcategory(ProductSubcategory productSubcategory)
        {
            return _productSubcategoryService.CreateProductSubcategory(productSubcategory);
        }

        [HttpPut]
        public bool UpdateProductSubcategory(ProductSubcategory productSubcategory)
        {
            return _productSubcategoryService.UpdateProductSubcategory(productSubcategory);
        }

        [HttpDelete("{id}")]
        public bool DeleteProductSubcategory(int id)
        {
            return _productSubcategoryService.DeleteProductSubcategory(id);
        }
    }
}
