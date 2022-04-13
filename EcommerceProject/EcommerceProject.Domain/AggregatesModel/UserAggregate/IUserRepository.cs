using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
    }
}
