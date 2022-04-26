using EcommerceProject.API;
using EcommerceProject.API.Dtos;
using EcommerceProject.Specflow.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceProject.Specflow.StepDefinitions
{
    [Binding]
    public class CreateProductDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly CreateProductRequest _request;
        private IActionResult _actionResult;
        public CreateProductDefinition(CreateProductRequest request, WebApplicationFactory<Startup> factory)
        {
            _request = request;
            _factory = factory;
        }
        [Given(@"the name is ""([^""]*)""")]
        public void GivenTheNameIs(string name)
        {
            _request.Name = name;
        }

        [Given(@"the moneyvalue value is (.*)")]
        public void GivenTheMoneyvalueValueIs(int value)
        {
            _request.MoneyValue = value;
        }

        [Given(@"the moneyvalue currency is ""([^""]*)""")]
        public void GivenTheMoneyvalueCurrencyIs(string currency)
        {
            _request.Currency = currency;
        }

        [Given(@"the trademark is ""([^""]*)""")]
        public void GivenTheTrademarkIs(string tradeMark)
        {
            _request.TradeMark = tradeMark;
        }

        [Given(@"the origin is ""([^""]*)""")]
        public void GivenTheOriginIs(string origin)
        {
            _request.Origin = origin;
        }

        [Given(@"the discription is ""([^""]*)""")]
        public void GivenTheDiscriptionIs(string discription)
        {
            _request.Discription = discription;
        }

        [When(@"the product is created")]
        public async Task WhenTheProductIsCreated()
        {
            string url = "https://localhost:7141/api/products";
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
        }

        [Then(@"the command result is success")]
        public void ThenTheCommandResultIsSuccess()
        {
            var result = _actionResult as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

    }
}
