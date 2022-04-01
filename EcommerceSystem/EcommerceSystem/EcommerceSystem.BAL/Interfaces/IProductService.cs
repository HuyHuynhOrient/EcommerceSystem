using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BAL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProductsList();
        Product GetProductbyID(int ProductID);
        bool CreateProduct(Product request);
        bool UpdateProduct(Product request);
        bool DeleteProduct(int ProductID);
    }
}
