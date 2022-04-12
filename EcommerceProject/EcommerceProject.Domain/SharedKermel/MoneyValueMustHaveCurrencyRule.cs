using EcommerceProject.Domain.SeedWork;

namespace EcommerceProject.Domain.SharedKermel
{
    public class MoneyValueMustHaveCurrencyRule : IBusinessRule
    {
        private readonly string _currency;

        public MoneyValueMustHaveCurrencyRule(string currentcy)
        {
            _currency = currentcy;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_currency);
        public string Message => "Money value must have currency";

    }
}
