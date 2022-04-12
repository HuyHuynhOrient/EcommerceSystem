using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class CustomerData
    {
        public Guid CustomerId { get; }
        public int CartId { get; }
        public CustomerData(Guid customerId, int cartId)
        {
            this.CustomerId = customerId;
            this.CartId = cartId;
        }
    }
}
