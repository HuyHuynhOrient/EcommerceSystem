using EcommerceSystem.BAL.Interfaces;
using EcommerceSystem.DAL.Interfaces;
using EcommerceSystem.Domain;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BAL.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        // Service get all ProductCategory
        public List<ProductCategory> GetProductCategoriesList()
        {
            return _productCategoryRepository.GetProductCategoriesList();
        }

        public ProductCategory GetProductCategorybyID(int ProductCategoryID)
        {
            return _productCategoryRepository.GetProductCategorybyID(ProductCategoryID);
        }

        public bool CreateProductCategory(ProductCategory request)
        {
            return _productCategoryRepository.CreateProductCategory(request);
        }

        public bool UpdateProductCategory(ProductCategory request)
        {
            return _productCategoryRepository.UpdateProductCategory(request);
        }
        public bool DeleteProductCategory(int ProductCategoryID)
        {
            return _productCategoryRepository.DeleteProductCategory(ProductCategoryID);
        }
    }
}
