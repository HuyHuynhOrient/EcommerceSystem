using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities
{
    public enum OrderStatus
    {
       Placed,
       InRealization,
       Canceled,
       Delivered,
       Sent,
       WaitingForPayment
    }
}
