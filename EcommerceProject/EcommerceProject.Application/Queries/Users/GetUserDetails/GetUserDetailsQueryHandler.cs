using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Customers.GetCustomerDetails
{
    public class GetUserDetailsQueryHandler : IQueryHandler<GetUserDetailsQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserDetailsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserDetailsQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.FindOneAsync(query.UserId, cancellationToken);
        }
    }
}
