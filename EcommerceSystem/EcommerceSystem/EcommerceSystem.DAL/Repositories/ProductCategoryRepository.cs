using EcommerceSystem.DAL.EF;
using EcommerceSystem.DAL.Interfaces;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EcommerceSystemContext _context;
        public ProductCategoryRepository(EcommerceSystemContext context)
        {
            _context = context;
        }

        // Repository get all ProductCategory
        public List<ProductCategory> GetProductCategoriesList()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            var db = _context.ProductCategories.ToList();
            db.ForEach(c =>
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.ProductCategoryID = c.ProductCategoryID;
                productCategory.Name = c.Name;
                productCategories.Add(productCategory);
            });
            return productCategories;
        }

        // Repository get ProductCategory by id
        public ProductCategory GetProductCategorybyID(int ProductCategoryID)
        {
            var productCategory = _context.ProductCategories.Find(ProductCategoryID);
            return productCategory;
        }

        // Repository create ProductCategory
        public bool CreateProductCategory(ProductCategory request)
        {
            var productCategory = new ProductCategoryEntity();
            productCategory.Name = request.Name;
            productCategory.ModifiedDate = DateTime.Now;
             _context.Add(productCategory);
             _context.SaveChanges();
            return true;
        }

        // Repository update ProductCategory
        public bool UpdateProductCategory(ProductCategory request)
        {
            var productCategory = _context.ProductCategories.Find(request.ProductCategoryID);
            if (productCategory == null) { 
                return false;
            }
            else
            {
                productCategory.Name = request.Name;
                productCategory.ModifiedDate = DateTime.Now;
                _context.Update(productCategory);
                _context.SaveChanges();
                return true;
            }
        }

        // Repository delete ProductCategory
        public bool DeleteProductCategory(int ProductCategoryID)
        {
            var productCategory = _context.ProductCategories.Find(ProductCategoryID);
            if(productCategory == null)
            {
                return false;
            }
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
            return true;
        }
    }
}
