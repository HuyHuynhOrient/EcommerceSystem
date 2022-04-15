using EcommerceProject.Domain.AggregatesModel.RoleAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using Xunit;

namespace EcommerceProject.Domain.Test
{
    public class UserAggregateTest
    {
        [Fact]
        public void GivenInformation_WhenCreatingUser_ThenItShouldBeCreate()
        {
            var username = "nguyenvana";
            var passwork = "Abc@123";
            var name = "Nguyen Van A";
            var email = "admin@gmail.com";
            var role = new Role(UserRole.Customer);

            var user = new User(username, passwork, name, email, role);

            Assert.Equal(username, user.UserName);
            Assert.Equal(passwork, user.Password);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
            Assert.Equal(role, user.Role);
        }
    }
}
