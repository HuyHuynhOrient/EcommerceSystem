using EcommerceProject.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities
{
    public interface IOrderRepository: IRepository<Customer, Guid>
    {
    }
}
