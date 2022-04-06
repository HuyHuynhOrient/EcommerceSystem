using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    public class OrderProduct : Entity<int>
    {
        public int ProductId { get; } // Aggregate relationship
        public int Quantity { get; private set; }
        public MoneyValue Value { get; private set; }
        private OrderProduct(OrderProductData orderProductData)
        {
            // Id propertiy is is set auto-increment
            this.ProductId = orderProductData.ProductId;
            this.Quantity = orderProductData.Quantity;
            CalculateOrderProductValue(orderProductData);
        }
        internal OrderProduct CreateAnOrderProduct(OrderProductData orderProductData)
        {
            return new OrderProduct(orderProductData);
        }
        internal void ChangeQuantity(OrderProductData orderProductData)
        {
            this.Quantity = orderProductData.Quantity;
            this.CalculateOrderProductValue(orderProductData);
        }
        internal void CalculateOrderProductValue(OrderProductData orderProductData)
        {
            this.Value = orderProductData.Quantity * orderProductData.Price;
        }
    }
}
