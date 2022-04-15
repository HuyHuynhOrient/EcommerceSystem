using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
    }
}
