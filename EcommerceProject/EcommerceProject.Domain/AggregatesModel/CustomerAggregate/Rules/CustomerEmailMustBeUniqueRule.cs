using EcommerceProject.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Rules
{
    public class CustomerEmailMustBeUniqueRule : IBusinessRule
    {
        private readonly string _email;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        public CustomerEmailMustBeUniqueRule(ICustomerUniquenessChecker customerUniquenessChecker, string email)
        {
            _customerUniquenessChecker = customerUniquenessChecker;
            _email = email;
        }

        public bool IsBroken() => _customerUniquenessChecker.IsUnique(_email);
        public string Message => "Customer with this email already exists.";
    }
}
