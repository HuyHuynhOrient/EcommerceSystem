using EcommerceProject.Domain.AggregatesRoot.RoleAggregate;
using EcommerceProject.Domain.AggregatesRoot.UserAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Test.Mock
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var user = new User("admin", "Abc@123", "Admin", "admin@mail.com", new Role(UserRole.Customer));
            user.Id = Guid.Parse("0893F0C0-6882-4741-526F-08DA21007655");

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(p => p.FindOneAsync(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(user);

            return mockUserRepo;
        }

        public static Mock<IUserRepository> GetNullUserRepository()
        {
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(p => p.FindOneAsync(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(() => null);

            return mockUserRepo;
        }
    }
}
