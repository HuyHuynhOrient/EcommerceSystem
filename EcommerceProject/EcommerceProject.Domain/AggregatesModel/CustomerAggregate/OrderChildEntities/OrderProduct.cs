using EcommerceProject.Domain.AggregatesModel.ProductAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities
{
    public class OrderProduct : Entity<int>
    {
        public int Quantity { get; private set; }
        public MoneyValue Value { get; private set; }
        public Product Product { get; } // Relationship
        private OrderProduct(Product product, int quantity)
        {
            // Set identity for Id value
            this.Product = product;
            this.Quantity = quantity;
            CalculateOrderProductValue(product, quantity);
        }
        internal OrderProduct CreateAnOrderProduct(Product product, int quantity)
        {
            return new OrderProduct(product, quantity);
        }
        internal void ChangeQuantity(Product product, int quantity)
        {
            this.Quantity = quantity;
            this.CalculateOrderProductValue(product, quantity);
        }
        internal void CalculateOrderProductValue(Product product, int quantity)
        {
            this.Value = quantity * product.Price;
        }
    }
}
