using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    public class Order : AggregateRoot<int>
    {
        public int CustormerId { get; } // Aggregate relationship
        public DateTime CreateDate { get; }
        public string ShippingAddress { get; }
        public string ShippingPhoneNumber { get; }
        public OrderStatus OrderStatus { get; private set; }
        public bool isRemoved { get; private set; }
        public MoneyValue Value { get; private set; } 
        public List<OrderProduct> OrderProducts { get; } // Navigation
        private Order(List<OrderProduct> orderProducts, int customerId, 
                            string shippingAddress, string shippingPhoneNumner)
        {
            // Id propertiy is is set auto-increment
            this.CustormerId = customerId;
            this.OrderProducts = orderProducts;
            CalculateOrderValue();
            this.CreateDate = DateTime.Now;
            this.ShippingAddress = shippingAddress;
            this.ShippingPhoneNumber = shippingPhoneNumner;
            this.OrderStatus = OrderStatus.Placed;
            this.isRemoved = false;
        }

        // Custommer create and remove an order
        internal static Order CreateNewOrder(List<OrderProduct> orderProducts, int customerId,
                                                string shippingAddress, string shippingPhoneNumner)
        {
            return new Order(orderProducts, customerId, shippingAddress, shippingPhoneNumner);
        }
        internal void RemoveOrder()
        {
            this.isRemoved = true;
        }

        // Admin change the order status
        internal void ChangeOrderStatus(OrderStatus orderStatus)
        {
            this.OrderStatus = orderStatus;
        }
        internal void CalculateOrderValue()
        {
            this.Value = this.OrderProducts.Sum(x => x.Value);
        }
    }
}
