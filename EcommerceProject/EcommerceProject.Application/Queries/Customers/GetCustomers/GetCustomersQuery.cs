using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Customers.GetCustomers
{
    public class GetCustomersQuery : IQuery<Customer>
    {
        public Guid CustomerId { get; set; }
    }
}
