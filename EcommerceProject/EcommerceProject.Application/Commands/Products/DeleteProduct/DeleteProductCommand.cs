using EcommerceProject.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}
