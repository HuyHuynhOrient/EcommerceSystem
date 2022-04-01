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
    public class ProductSubcategoryService : IProductSubcategoryService
    {
        private readonly IProductSubcategoryRepository _productSubcategoryRepository;
        public ProductSubcategoryService(IProductSubcategoryRepository productSubcategoryRepository)
        {
            _productSubcategoryRepository = productSubcategoryRepository;
        }

        public List<ProductSubcategory> GetProductSubcategoriesList()
        {
            return _productSubcategoryRepository.GetProductSubcategoriesList();
        }

        public ProductSubcategory GetProductSubcategorybyID(int ProductSubcategoryID)
        {
            return _productSubcategoryRepository.GetProductSubcategorybyID(ProductSubcategoryID);
        }

        public bool CreateProductSubcategory(ProductSubcategory request)
        {
            return _productSubcategoryRepository.CreateProductSubcategory(request);
        }

        public bool UpdateProductSubcategory(ProductSubcategory request)
        {
            return _productSubcategoryRepository.UpdateProductSubcategory(request);
        }

        public bool DeleteProductSubcategory(int id)
        {
            return _productSubcategoryRepository.DeleteProductSubcategory(id);
        }
    }
}
