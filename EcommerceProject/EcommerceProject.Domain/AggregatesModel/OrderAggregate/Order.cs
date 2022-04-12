using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    public class Order : AggregateRoot<int>
    {
        public Guid CustomerId { get; }
        public DateTime CreateDate { get; }
        public string ShippingAddress { get; }
        public string ShippingPhoneNumber { get; }
        public OrderStatus OrderStatus { get; private set; }
        public MoneyValue Value { get; private set; } 
        public List<OrderProduct> OrderProducts { get; }

        private Order()
        {
        }

        public Order(Guid customerId, string shippingAddress, string shippingPhoneNumber, MoneyValue value, List<OrderProduct> orderProducts)
        {
            this.CustomerId = customerId;
            this.CreateDate = DateTime.Now;
            this.ShippingAddress = shippingAddress;
            this.ShippingPhoneNumber = shippingPhoneNumber;
            this.OrderStatus = OrderStatus.Placed;
            this.Value = value;
            this.OrderProducts = orderProducts;
        }
        public void ChangeOrderStatus(OrderStatus orderStatus)
        {
            this.OrderStatus = orderStatus;
        }
    }
}
