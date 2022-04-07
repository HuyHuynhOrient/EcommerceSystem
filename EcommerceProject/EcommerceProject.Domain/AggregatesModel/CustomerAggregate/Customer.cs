using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Rules;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer : AggregateRoot<int>
    {
        public string Name { get; }
        public string UserName { get; }
        public string Email { get; }

        private Customer(string name, string userName, string email)
        {
            // Id propertiy is is set auto-increment
            this.Name = name;
            this.UserName = userName;
            this.Email = email;
        }
        internal static Customer CreateRegisterCustomer(string name, string userName, string email, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));
            return new Customer(name, userName, email);
        }
    }
}
