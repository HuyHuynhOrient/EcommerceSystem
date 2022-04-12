using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.Database;

namespace EcommerceProject.Infrastructure.Domain.Repository
{
    internal class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
