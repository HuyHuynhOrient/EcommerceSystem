using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    public class User : AggregateRoot<Guid>
    {
        public string Name { get; }
        public string UserName { get; }
        public string Password { get; }
        public string Email { get; }
        public UserRole UserRole { get; }

        private User()
        {
        }

        public User(string userName, string passWord, string name, string email, UserRole userRole)
        {
            this.UserName = userName;
            this.Password = passWord;
            this.Name = name;
            this.Email = email;
            this.UserRole = userRole;
        }
    }
}
