using EcommerceSystem.BAL.Interfaces;
using EcommerceSystem.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public List<ProductCategory> GetProductCategoriesList()
        {
            return _productCategoryService.GetProductCategoriesList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductCategory> GetProductCategorybyID(int id)
        {
            var productCategory = _productCategoryService.GetProductCategorybyID(id);
            if (productCategory == null)
            {
                return NotFound("Invalid ID");
            }
            return productCategory;
        }

        [HttpPost]
        public bool CreateProductCategory(ProductCategory request)
        {
            return _productCategoryService.CreateProductCategory(request);
        }

        [HttpPut]
        public bool UpdateProductCategory(ProductCategory request)
        {
            return _productCategoryService.UpdateProductCategory(request);
        }

        [HttpDelete("{id}")]
        public bool DeleteProductCategory(int id)
        {
            return _productCategoryService.DeleteProductCategory(id);
        }
    }
}
