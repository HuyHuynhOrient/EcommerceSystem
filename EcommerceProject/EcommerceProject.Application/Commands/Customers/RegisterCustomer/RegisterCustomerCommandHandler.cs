using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, CustomerData>
    {
        private readonly IUserRepository _customerRepository;
        private readonly ICartRepository _cartRepository;

        public RegisterCustomerCommandHandler(IUserRepository customerRepository, ICartRepository cartRepository)
        {
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;   
        }

        public async Task<CommandResult<CustomerData>> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.FindAllAsync(null, cancellationToken);
            var customerExist = customers.FirstOrDefault(x => x.UserName == command.UserName);
            if (customerExist != null) return CommandResult<CustomerData>.Error("UserName already exists.");
            
            var customer = new User(command.UserName, command.Password, command.Name, command.Email, UserRole.Customer);
            await _customerRepository.AddAsync(customer, cancellationToken);

            var cart = new Cart(customer.Id);
            await _cartRepository.AddAsync(cart, cancellationToken);

            var customerData = new CustomerData(customer.Id, cart.Id);

            return CommandResult<CustomerData>.Success(customerData);
        }
    }
}
