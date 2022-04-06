using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.OrderAggregate
{
    // Definition product data for ordering. 
    internal class OrderProductData
    {
        internal int ProductId { get; }
        internal MoneyValue Price { get; }
        internal int Quantity { get; }
        internal OrderProductData(int productId, MoneyValue price, int quantity)
        {
            this.ProductId = productId;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
