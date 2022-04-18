using EcommerceProject.Application.Test.Mock;
using EcommerceProject.Domain.AggregatesRoot.CartAggregate;
using EcommerceProject.Domain.AggregatesRoot.UserAggregate;
using EcommerceProject.Domain.SeedWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Application.Test
{
    public class CartAggregateTest
    {
        [Fact]
        public void GetCartDetails_ReturnAvailableCart()
        {
            //Arrage
            var mockUserRepository = new Mock<IUserRepository>();

            var userId = Guid.Parse("0893F0C0-6882-4741-526F-08DA21007655");
            CancellationToken cancellationToken = default;

            mockUserRepository.Setup(x => x.FindOneAsync(userId, cancellationToken)).Returns(new User();

            //Act

            //Assert
        }
    }
}
