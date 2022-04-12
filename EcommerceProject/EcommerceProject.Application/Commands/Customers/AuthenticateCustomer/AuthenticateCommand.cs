using EcommerceProject.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Customers.AuthenticateCustomer
{
    public class AuthenticateCommand : ICommand<string>
    {
        public Guid CustomerId { get; init; }
        public string UserName { get; init; }
        public bool RememberMe { get; init; }
    }
}
