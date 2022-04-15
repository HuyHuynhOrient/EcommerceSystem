using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.RoleAggregate
{
    public class Role : AggregateRoot<int>
    {
        public string Name { get; }

        private Role()
        {
        }

        public Role(string name)
        {
            this.Name = name;
        }
    }
}
