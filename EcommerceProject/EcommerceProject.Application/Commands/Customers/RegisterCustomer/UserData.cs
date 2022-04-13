using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Customers.RegisterCustomer
{
    public class UserData
    {
        public Guid UserId { get; }
        public int CartId { get; }
        public UserData(Guid userId, int cartId)
        {
            this.UserId = userId;
            this.CartId = cartId;
        }
    }
}
