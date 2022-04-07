using EcommerceProject.Domain.AggregatesModel.OrderAggregate;
using EcommerceProject.Domain.SeedWork;
using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.AggregatesModel.CustomerAggregate.Rules
{
    public class TheOrderMustHaveTheSameCurrencyRule : IBusinessRule
    {

        private readonly List<OrderProduct> _orderProducts;
        public TheOrderMustHaveTheSameCurrencyRule(List<OrderProduct> orderProduct)
        {
            _orderProducts = orderProduct;
        }

        public bool IsBroken()
        {
            var result = true;
            var leftValue = _orderProducts.FirstOrDefault().Value;
            foreach (var orderProduct in _orderProducts)
            {
                var check = new MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(leftValue, orderProduct.Value).IsBroken();
                if (check == false)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public string Message => "The order must have the same currency.";
    }
}
