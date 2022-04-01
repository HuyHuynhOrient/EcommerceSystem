using EcommerceSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL.Interfaces
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetProductCategoriesList();
        ProductCategory GetProductCategorybyID(int ProductCategoryID);
        bool CreateProductCategory(ProductCategory request);
        bool UpdateProductCategory(ProductCategory request);
        bool DeleteProductCategory(int ProductCategoryID);
    }
}
