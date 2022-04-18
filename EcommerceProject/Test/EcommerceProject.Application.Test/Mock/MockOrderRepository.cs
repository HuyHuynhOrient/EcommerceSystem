using EcommerceProject.Domain.AggregatesRoot.OrderAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Test.Mock
{
    public class MockOrderRepository : Mock<IOrderRepository>
    {
    }
}
