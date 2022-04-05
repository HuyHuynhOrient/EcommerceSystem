﻿using EcommerceProject.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.SharedKermel
{
    public class MoneyValueOperationMustBePerformedOnTheSameCurrencyRule : IBusinessRule
    {
        private readonly MoneyValue _left;
        private readonly MoneyValue _right;
        public MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(MoneyValue left, MoneyValue right)
        {
            _left = left;
            _right = right;
        }

        public bool IsBroken() => _left != _right;
        public string Message => "Money value currencies must be the same";
    }
}
