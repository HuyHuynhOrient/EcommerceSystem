using EcommerceSystem.DAL.EF;
using EcommerceSystem.DAL.Interfaces;
using EcommerceSystem.Domain;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Repositories
{
    public class ProductSubcategoryRepository : IProductSubcategoryRepository
    {
        private readonly EcommerceSystemContext _context;
        public ProductSubcategoryRepository(EcommerceSystemContext context)
        {
            _context = context;
        }
        public List<ProductSubcategory> GetProductSubcategoriesList()
        {
            List<ProductSubcategory> productSubcategories = new List<ProductSubcategory>();
            var db = _context.ProductSubcategories.ToList();
            db.ForEach(c =>
            {
                ProductSubcategory productSubcategory = new ProductSubcategory();
                productSubcategory.ProductSubcategoryID = c.ProductSubcategoryID;
                productSubcategory.ProductCategoryID = c.ProductCategoryID;
                productSubcategory.Name = c.Name;
                productSubcategories.Add(productSubcategory);
            });
            return productSubcategories;
        }

        public ProductSubcategory GetProductSubcategorybyID(int ProductSubcategoryID)
        {
            var productSubcategory = _context.ProductSubcategories.Find(ProductSubcategoryID);
            return productSubcategory;
        }

        public bool CreateProductSubcategory(ProductSubcategory request)
        {
            var productSubcategory = new ProductSubcategoryEntity();
            productSubcategory.ProductCategoryID = request.ProductCategoryID;
            productSubcategory.Name = request.Name;
            productSubcategory.ModifiedDate = DateTime.Now;
            _context.Add(productSubcategory);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProductSubcategory(ProductSubcategory request)
        {
            var productSubcategory = _context.ProductSubcategories.Find(request.ProductSubcategoryID);
            if (productSubcategory == null)
            {
                return false;
            }
            else
            {
                productSubcategory.ProductCategoryID = request.ProductCategoryID;
                productSubcategory.Name = request.Name;
                productSubcategory.ModifiedDate = DateTime.Now;
                _context.Update(productSubcategory);
                _context.SaveChanges();
                return true;
            }
            
        }
        public bool DeleteProductSubcategory(int ProductSubcategoryID)
        {
            var productSubcategory = _context.ProductSubcategories.Find(ProductSubcategoryID);
            if (productSubcategory == null)
            {
                return false;
            }
            else
            {
                _context.ProductSubcategories.Remove(productSubcategory);
                _context.SaveChanges();
                return true;
            }
        }

    }
}
