using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, UserData>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;

        public RegisterCustomerCommandHandler(IUserRepository userRepository, ICartRepository cartRepository)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;   
        }

        public async Task<CommandResult<UserData>> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindAllAsync(null, cancellationToken);
            var user = users.FirstOrDefault(x => x.UserName == command.UserName);
            if (user != null) return CommandResult<UserData>.Error("User Name already exists.");
            
            var customer = new User(command.UserName, command.Password, command.Name, command.Email, UserRole.Customer);
            await _userRepository.AddAsync(customer, cancellationToken);

            var cart = new Cart(customer.Id);
            await _cartRepository.AddAsync(cart, cancellationToken);
            var customerData = new UserData(customer.Id, cart.Id);

            return CommandResult<UserData>.Success(customerData);
        }
    }
}
