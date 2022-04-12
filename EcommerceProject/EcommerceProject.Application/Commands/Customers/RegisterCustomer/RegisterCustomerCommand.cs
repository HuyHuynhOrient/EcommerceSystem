using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class RegisterCustomerCommand : ICommand<Guid>
    {
        public string Name { get; init; }
        public string UserName {  get ; init ; }
        public string Email {  get ; init ; }
    }
}
