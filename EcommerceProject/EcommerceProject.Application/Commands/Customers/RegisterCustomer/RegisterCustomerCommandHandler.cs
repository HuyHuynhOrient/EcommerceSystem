using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository, ICartRepository cartRepository)
        {
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;   
        }

        public async Task<CommandResult<Guid>> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.FindAllAsync(null, cancellationToken);
            var customerExist = customers.FirstOrDefault(x => x.Email == command.Email);
            if (customerExist != null) return CommandResult<Guid>.Error("Email already exists.");
            
            var customer = new Customer(command.Name, command.UserName, command.Email);
            await _customerRepository.AddAsync(customer, cancellationToken);

            var cart = new Cart(customer.Id);
            await _cartRepository.AddAsync(cart, cancellationToken);

            return CommandResult<Guid>.Success(customer.Id);
        }
    }
}
