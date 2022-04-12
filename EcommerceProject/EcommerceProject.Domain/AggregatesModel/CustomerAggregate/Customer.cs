using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer : AggregateRoot<Guid>
    {
        public string Name { get; }
        public string UserName { get; }
        public string Email { get; }

        public Customer(string name, string userName, string email)
        {
            this.Name = name;
            this.UserName = userName;
            this.Email = email;
        }
    }
}
