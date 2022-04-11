using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Infrastructure.Database;

namespace EcommerceProject.Infrastructure.Domain.Repository
{
    internal class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
