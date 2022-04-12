using EcommerceProject.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Carts.ChangeProductQuantity
{
    public class ChangeProductQuantityCommand : ICommand<int>
    {
        public int CartId { get; init; }
        public int CartProductId { get; init; }
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
