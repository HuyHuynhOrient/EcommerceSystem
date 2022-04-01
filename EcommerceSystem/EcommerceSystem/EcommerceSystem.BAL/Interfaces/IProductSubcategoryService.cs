using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BAL.Interfaces
{
    public interface IProductSubcategoryService
    {
        List<ProductSubcategory> GetProductSubcategoriesList();
        ProductSubcategory GetProductSubcategorybyID(int ProductSubcategoryID);
        bool CreateProductSubcategory(ProductSubcategory request);
        bool UpdateProductSubcategory(ProductSubcategory request);
        bool DeleteProductSubcategory(int ProductSubcategoryID);
    }
}
