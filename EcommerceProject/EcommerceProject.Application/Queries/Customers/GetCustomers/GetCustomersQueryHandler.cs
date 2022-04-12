using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Customers.GetCustomers
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.FindOneAsync(query.CustomerId, cancellationToken);
        }
    }
}
