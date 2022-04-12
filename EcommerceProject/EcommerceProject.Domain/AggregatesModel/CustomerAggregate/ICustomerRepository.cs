using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository : IBaseRepository<Customer, Guid>
    {
    }
}
