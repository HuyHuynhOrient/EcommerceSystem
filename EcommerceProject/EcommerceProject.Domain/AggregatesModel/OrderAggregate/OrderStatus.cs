using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    // Definition statuses of the order. 
    public enum OrderStatus
    {
        Cart,
        Placed,
        InRealization,
        Canceled,
        Delivered,
        Sent,
        WaitingForPayment
    }
}
