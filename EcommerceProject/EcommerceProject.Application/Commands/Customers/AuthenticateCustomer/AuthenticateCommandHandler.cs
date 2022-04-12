using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _config;

        public AuthenticateCommandHandler(ICustomerRepository customerRepository, IConfiguration config)
        {
            _customerRepository = customerRepository;
            _config = config;
        }

        public async Task<CommandResult<string>> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindOneAsync(command.CustomerId, cancellationToken);

            if (customer == null) return CommandResult<string>.Error("Customer is not valid.");

            var claims = new[]
             {
                new Claim(ClaimTypes.GivenName, command.UserName),
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
