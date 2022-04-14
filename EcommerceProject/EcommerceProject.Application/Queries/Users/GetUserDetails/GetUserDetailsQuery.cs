﻿using EcommerceProject.Domain.AggregatesModel.CustomerAggregate;
using EcommerceProject.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Application.Queries.Customers.GetCustomerDetails
{
    public class GetUserDetailsQuery : IQuery<User>
    {
        public Guid UserId { get; set; }
    }
}
