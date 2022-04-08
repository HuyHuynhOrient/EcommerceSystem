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
        public int CustomerId { get; } // Aggregate relationship
        public DateTime CreateDate { get; }
        public string ShippingAddress { get; }
        public string ShippingPhoneNumber { get; }
        public bool isRemoved { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public MoneyValue Value { get; private set; } 
        public List<OrderProduct> OrderProducts { get; } // Navigation

        private Order()
        {

        }

        public Order(int customerId, string shippingAddress, string shippingPhoneNumber)
        {
            // Id propertiy is is set auto-increment
            this.CustomerId = customerId;
            this.CreateDate = DateTime.Now;
            this.ShippingAddress = shippingAddress;
            this.ShippingPhoneNumber = shippingPhoneNumber;
            this.isRemoved = false;
            this.OrderStatus = OrderStatus.Placed;
            this.OrderProducts = new List<OrderProduct>();
        }

        internal void CalculateOrderValue()
        {
            this.Value = this.OrderProducts.Sum(x => x.Value);
        }

        internal void AddOrderProduct(int productId, int quantity, MoneyValue price)
        {
            MoneyValue value = quantity * price;
            OrderProduct orderproduct = new OrderProduct(productId, quantity, value);
            this.OrderProducts.Add(orderproduct);
            CalculateOrderValue();
        }
        internal void RemoveOrderProduct(OrderProduct orderProduct)
        {
            this.OrderProducts.Remove(orderProduct);
            CalculateOrderValue();
        }
    }
}
