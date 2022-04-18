using EcommerceProject.Domain.AggregatesRoot.UserAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Test.Mock
{
    internal class MockUserRepository : Mock<IUserRepository>
    {
    }
}
