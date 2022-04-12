using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;

namespace EcommerceProject.Domain.AggregatesModel.CartAggregate
{
    public class CartProduct : Entity<int>
    {
        public int ProductId { get; }
        public int Quantity { get; private set; }
        public MoneyValue Value { get; private set; }

        private CartProduct()
        {
        }

        public CartProduct(int productId, int quantity, MoneyValue value)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Value = value;
        }

        public void ChangeQuantity(int quantity, MoneyValue value)
        {
            this.Quantity = quantity;
            this.Value = value;
        }
    }
}
