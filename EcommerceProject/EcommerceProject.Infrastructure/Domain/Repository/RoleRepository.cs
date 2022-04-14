using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Infrastructure.Database;

namespace EcommerceProject.Infrastructure.Domain.Repository
{
    internal class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
