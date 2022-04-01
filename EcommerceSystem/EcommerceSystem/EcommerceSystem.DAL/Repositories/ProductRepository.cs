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
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceSystemContext _context;
        public ProductRepository(EcommerceSystemContext context)
        {
            _context = context;
        }

        // Repository get all Product
        public List<Product> GetProductsList()
        {
            List<Product> products = new List<Product>();
            var db = _context.Products.ToList();
            db.ForEach(c =>
            {
                Product product = new Product();
                product.ProductID = c.ProductID;
                product.Name = c.Name;
                product.Price = c.Price;
                product.ProductNumber = c.ProductNumber;
                product.TradeMark = c.TradeMark;
                product.Origin = c.Origin;
                product.Discription = c.Discription;
                product.ProductSubcategoryID = c.ProductSubcategoryID;
                products.Add(product);
            });
            return products;
        }

        // Repository get Product by id
        public Product GetProductbyID(int ProductID)
        {
            var product = _context.Products.Find(ProductID);
            return product;
        }

        // Repository create Product
        public bool CreateProduct(Product request)
        {
            var product = new ProductEntity();
            product.Name = request.Name;
            product.Price = request.Price;
            product.ProductNumber = request.ProductNumber;
            product.TradeMark = request.TradeMark;
            product.Origin = request.Origin;
            product.Discription = request.Discription;
            product.ProductSubcategoryID = request.ProductSubcategoryID;
            product.ModifiedDate = DateTime.Now;
            _context.Add(product);
            _context.SaveChanges();
            return true;
        }

        // Repository update Product
        public bool UpdateProduct(Product request)
        {
            var product = _context.Products.Find(request.ProductID);
            if (product == null)
            {
                return false;
            }
            else
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.ProductNumber = request.ProductNumber;
                product.TradeMark = request.TradeMark;
                product.Origin = request.Origin;
                product.Discription = request.Discription;
                product.ProductSubcategoryID = request.ProductSubcategoryID;
                product.ModifiedDate = DateTime.Now;
                _context.Update(product);
                _context.SaveChanges();
                return true;
            }
            _context.Update(product);
            _context.SaveChanges();
        }


        // Repository delete Product
        public bool DeleteProduct(int ProductID)
        {
            var product = _context.Products.Find(ProductID);
            if(product == null) 
            { 
                return false; 
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }

        }
    }
}
