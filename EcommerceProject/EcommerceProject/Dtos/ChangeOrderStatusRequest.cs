using EcommerceProject.Domain.AggregatesModel.OrderAggregate;

namespace EcommerceProject.API.Dtos
{
    public class ChangeOrderStatusRequest
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
