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

        private OrderProduct()
        {

        }

        public OrderProduct(int productId, int quantity, MoneyValue value)
        {
            //Id propertiy is is set auto - increment
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Value = value;
        }
        internal void ChangeQuantity(int quantity, MoneyValue value)
        {
            this.Quantity = quantity;
            this.Value = value;
        }
    }
}
