using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.Database;

namespace EcommerceProject.Infrastructure.Domain.Repository
{
    internal class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
