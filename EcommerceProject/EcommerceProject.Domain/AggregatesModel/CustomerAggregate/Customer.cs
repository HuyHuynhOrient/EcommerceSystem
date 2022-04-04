using EcommerceProject.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    internal class Customer : AggregateRoot<Guid>
    {
        private string Name { get; }
        private string UserName { get; }
        private Customer(string name, string userName)
        {
            this.Name = name;
            this.UserName = userName;
        }
    }
}
