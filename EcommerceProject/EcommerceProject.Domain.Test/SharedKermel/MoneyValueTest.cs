using EcommerceProject.Domain.SharedKermel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Domain.Test.SharedKermel
{
    public class MoneyValueTest
    {
        [Fact]
        public void MoneyValueOf_WhenProvidingCurrency_IsSuccessful()
        {
            decimal value = 300;
            var currency = "USA";

            var moneyvalue = MoneyValue.Of(value, currency);

            Assert.Equal(value, moneyvalue.Value);
            Assert.Equal(currency, moneyvalue.Currency);
        }

        [Fact] 
        public void MoneyValueOf_WhenNotProvidingCurrency_ThrowsMoneyValueMustHaveCurrencyRuleBroken()
        {
        }

        [Fact] 
        public void GivenMoneyValue_WhenAddingTwoMoneyValues_IsSuccessful()
        {
            var value1 = MoneyValue.Of(100, "USA");
            var value2 = MoneyValue.Of(200, "USA");

            var sumMoneyValue = value1 + value2;

            Assert.Equal(MoneyValue.Of(300, "USA"), sumMoneyValue);
        }

        [Fact] 
        public void GivenMoneyValue_WhenMultiplyingMoneyValuesWithIntNumber_IsSuccessful()
        {
            var value = MoneyValue.Of(100, "USA");
            var number = 3;

            var multipValue = number * value;

            Assert.Equal(MoneyValue.Of(300, "USA"), multipValue);
        }

        [Fact]
        public void GivenMoneyValue_WhenMultiplyingMoneyValuesWithDecimalNumber_IsSuccessful()
        {
            var value = MoneyValue.Of(100, "USA");
            decimal number = 3;

            var multipValue = number * value;

            Assert.Equal(MoneyValue.Of(300, "USA"), multipValue);
        }
    }
}
