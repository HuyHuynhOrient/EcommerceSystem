using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Customers.GetCustomers
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _customerRepository;

        public GetCustomersQueryHandler(IUserRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.FindAllAsync(null, cancellationToken);
        }
    }
}
