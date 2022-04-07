using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Infrastructure.Domain.Repository
{
    internal class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
