using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    public class Order : AggregateRoot<int>
    {
        public Guid UserId { get; }
        public DateTime CreateDate { get; }
        public string ShippingAddress { get; }
        public string ShippingPhoneNumber { get; }
        public OrderStatus OrderStatus { get; private set; }
        public MoneyValue Value { get; private set; } 
        public List<OrderProduct> OrderProducts { get; }

        private Order()
        {
        }

        public Order(Guid userId, string shippingAddress, string shippingPhoneNumber, 
            List<OrderProduct> orderProducts)
        {
            this.UserId = userId;
            this.CreateDate = DateTime.Now;
            this.ShippingAddress = shippingAddress;
            this.ShippingPhoneNumber = shippingPhoneNumber;
            this.OrderStatus = OrderStatus.Placed;
            this.OrderProducts = orderProducts;
            CalculateOrderValue();
        }

        public void ChangeOrderStatus(OrderStatus orderStatus)
        {
            this.OrderStatus = orderStatus;
        }

        public void CalculateOrderValue()
        {
            this.Value = this.OrderProducts.Sum(x => x.Value);
        }
    }
}
