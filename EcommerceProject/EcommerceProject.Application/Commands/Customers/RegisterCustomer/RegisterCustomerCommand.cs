using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class RegisterCustomerCommand : ICommand<CustomerData>
    {
        public string UserName { get ; init ; }
        public string Password { get; init; }
        public string Name { get; init; }
        public string Email { get ; init ; }
    }
}
