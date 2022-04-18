using EcommerceProject.Domain.AggregatesRoot.ProductAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Test.Mock
{
    internal class MockProductRepository : Mock<IProductRepository>
    {
    }
}
