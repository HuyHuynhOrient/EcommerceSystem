using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Domain.AggregatesModel.UserAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Infrastructure.CQRS.Command;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Customers.AuthenticateCustomer
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthenticateCommandHandler(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<CommandResult<string>> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindAllAsync(null, cancellationToken);
            var customer = users.FirstOrDefault(x => x.UserName == command.UserName && x.Password == command.Password && x.UserRole == UserRole.Customer);

            if (customer == null) return CommandResult<string>.Error("Customer is not valid.");

            var claims = new[]
             {
                new Claim(ClaimTypes.GivenName, customer.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            var JwTToken = new JwtSecurityTokenHandler().WriteToken(token);
            return CommandResult<string>.Success(JwTToken);

        }
    }
}
