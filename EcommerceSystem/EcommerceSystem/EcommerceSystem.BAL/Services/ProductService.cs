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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProductsList()
        {
            return _productRepository.GetProductsList();
        }

        public Product GetProductbyID(int ProductID)
        {
            return _productRepository.GetProductbyID(ProductID);
        }

        public bool CreateProduct(Product request)
        {
            return _productRepository.CreateProduct(request);
        }

        public bool UpdateProduct(Product request)
        {
            return _productRepository.UpdateProduct(request);
        }

        public bool DeleteProduct(int ProductID)
        {
            return _productRepository.DeleteProduct(ProductID);
        }

    }
}
