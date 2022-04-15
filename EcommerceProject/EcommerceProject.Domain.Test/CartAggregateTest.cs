using EcommerceProject.Domain.AggregatesModel.CartAggregate;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Domain.Test
{
    public class CartAggregateTest
    {
        [Fact]
        public void GivenInformation_WhenCreatingCart_ThenItShouldBeCreated()
        {
            var userId = Guid.NewGuid();

            var cart = new Cart(userId);

            Assert.Equal(userId, cart.UserId);
            Assert.Null(cart.Value);
            Assert.Empty(cart.CartProducts);
        }

        [Fact]
        public void GivenValue_WhenCalculatingThePriceOfProduct_ThenItShouldBeExactly()
        {
            var price = new MoneyValue(100, "USA");
            var quantity = 2;

            var value = quantity * price;

            Assert.Equal(new MoneyValue(200, "USA"), value);
        }

        [Fact]
        public void GivenInformation_WhenCreatingCartProduct_ThenItShouldBeCreated()
        {
            var productId = 1;
            var price = new MoneyValue(100, "USA");
            var quantity = 2;

            var cartProduct = new CartProduct(productId, quantity, price);

            Assert.Equal(productId, cartProduct.ProductId);
            Assert.Equal(quantity, cartProduct.Quantity);
            Assert.Equal(price, cartProduct.Price);
            Assert.Equal(quantity * price, cartProduct.Value);
        }

        [Fact]
        public void GivenValue_WhenCalculatingTheValueOfCart_ThenItShouldExactly()
        {

            var cartProduct1 = GivenSampleCartProduct1();
            var cartProduct2 = GivenSampleCartProduct2();
            var cart = GivenSampleCart();

            cart.AddCartProduct(cartProduct1);
            cart.AddCartProduct(cartProduct2);

            Assert.Equal(cartProduct1.Value + cartProduct2.Value, cart.Value);
        }

        [Fact]
        public void GivenACart_WhenAddCartProductToCart_ThenInShoudldBeAdd()
        {
            var cartProduct1 = GivenSampleCartProduct1();
            var cartProduct2 = GivenSampleCartProduct2();
            var cart = GivenSampleCart();

            cart.AddCartProduct(cartProduct1);
            cart.AddCartProduct(cartProduct2);

            Assert.Equal(2, cart.CartProducts.Count);
            Assert.Equal(cartProduct1.ProductId, cart.CartProducts[0].ProductId);
            Assert.Equal(cartProduct1.Value, cart.CartProducts[0].Value);
            Assert.Equal(cartProduct2.ProductId, cart.CartProducts[1].ProductId);
            Assert.Equal(cartProduct2.Value, cart.CartProducts[1].Value);

        }

        [Fact]
        public void GivenInformation_WhenChangingQuantityCartProduct_ThenItShouldBeChangedAndReCalculatedValue()
        {
            var cartProduct = GivenSampleCartProduct1();
            var cart = GivenSampleCart();
            var quantityChanged = 2;

            cart.AddCartProduct(cartProduct);
            cart.ChangeCartProductQuantity(cartProduct.Id, quantityChanged);

            var valueChanged = quantityChanged * cartProduct.Price;
            Assert.Equal(valueChanged, cart.Value);
            Assert.Equal(quantityChanged, cart.CartProducts[0].Quantity);
            Assert.Equal(valueChanged, cart.CartProducts[0].Value);
        }

        [Fact]
        public void GivenACart_WhenRemovingCartProduct_ThenItShouldBeRemoved()
        {
            var cartProduct1 = GivenSampleCartProduct1();
            var cart = GivenSampleCart();

            cart.AddCartProduct(cartProduct1);
            cart.RemoveCartProduct(cartProduct1.Id);

            Assert.Empty(cart.CartProducts);
        }

        [Fact]
        public void GivenACart_WhenRemovingAllCartProduct_ThenItShouldBeEmpty()
        {
            var cartProduct1 = GivenSampleCartProduct1();
            var cartProduct2 = GivenSampleCartProduct2();
            var cart = GivenSampleCart();

            cart.AddCartProduct(cartProduct1);
            cart.AddCartProduct(cartProduct2);
            cart.RemoveAllCartProduct();

            Assert.Empty(cart.CartProducts);
        }

        private Cart GivenSampleCart()
        {
            var userId = Guid.NewGuid();
            return new Cart(userId);
        }

        private CartProduct GivenSampleCartProduct1()
        {
            var productId = 1;
            var price = new MoneyValue(15, "USA");
            var quantity = 3;

            return new CartProduct(productId, quantity, price);
        }

        private CartProduct GivenSampleCartProduct2()
        {
            var productId = 2;
            var price = new MoneyValue(20, "USA");
            var quantity = 5;

            return new CartProduct(productId, quantity, price);
        }
    }
}
