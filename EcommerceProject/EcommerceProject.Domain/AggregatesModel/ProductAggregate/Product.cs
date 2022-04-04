using EcommerceProject.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.ProductAggregate
{
    // Aggregate root
    internal class Product : AggregateRoot<Guid>
    {
        private string Name { get; }
        private int Price { get; }
        private Product()
        {

        }
    }
}
