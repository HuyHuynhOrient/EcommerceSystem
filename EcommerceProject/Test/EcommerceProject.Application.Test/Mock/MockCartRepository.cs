using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.SeedWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Test.Mock
{
    public class MockCartRepository : Mock<ICartRepository>
    {
    }
}
