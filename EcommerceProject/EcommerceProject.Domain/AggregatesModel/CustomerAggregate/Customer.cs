using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.OrderChildEntities;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Orders;
using EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Rules;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer : AggregateRoot<Guid>
    {
        public string Name { get; }
        public string UserName { get; }
        public string Email { get; }
        public List<Order> Orders { get; private set; }

        private Customer(string name, string userName)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.UserName = userName;
            this.Orders = new List<Order>();
        }
        internal static Customer CreateRegisterCustomer(string name, string userName, string email, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));
            return new Customer(name, userName);
        }
        internal Guid PlaceOrder(List<OrderProduct> orderProducts, string shippingAddress, string shippingPhoneNumner)
        {
            CheckRule(new TheOrderMustHaveTheSameCurrencyRule(orderProducts));
            var order = Order.CreateNewOrder(orderProducts, shippingAddress, shippingPhoneNumner);
            this.Orders.Add(order);
            return order.Id;
        }
        internal void RemoveOrder(Guid orderId)
        {
            var order = this.Orders.Single(x => x.Id == orderId);
            order.RemoveOrder();
        }
    }
}
