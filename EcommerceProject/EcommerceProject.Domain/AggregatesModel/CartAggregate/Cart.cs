using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;

namespace EcommerceProject.Domain.AggregatesModel.CartAggregate
{
    public class Cart : AggregateRoot<int>
    {
        public Guid CustomerId { get; }
        public MoneyValue Value { get; private set; }
        public List<CartProduct> CartProducts { get; private set; }

        private Cart()
        {
        }

        public Cart(Guid customerId)
        {
            this.CustomerId = customerId;
            this.Value = null;
            this.CartProducts = new List<CartProduct>();
        }

        public void AddCartProduct(int productId, int quantity, MoneyValue value)
        {
            var orderProduct = new CartProduct(productId, quantity, value);
            this.CartProducts.Add(orderProduct);
            CalculateCartValue();
        }

        public void ChangeCartProductQuantity(int orderProductId, int quantity, MoneyValue value)
        {
            var order = CartProducts.Find(x => x.Id == orderProductId);
            order.ChangeQuantity(quantity, value);
            CalculateCartValue();
        }

        public void RemoveCartProduct(int orderProductId)
        {
            var orderProduct = CartProducts.Find(x => x.Id == orderProductId);
            this.CartProducts.Remove(orderProduct);
            CalculateCartValue();
        }

        public void RemoveAllCartProduct()
        {
            this.CartProducts = new List<CartProduct>();
            this.Value = null;
        }
        public void CalculateCartValue()
        {
            this.Value = this.CartProducts.Sum(x => x.Value);
        }
    }
}
