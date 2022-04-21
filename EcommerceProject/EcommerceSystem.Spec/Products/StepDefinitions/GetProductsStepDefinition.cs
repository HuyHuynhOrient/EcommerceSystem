using EcommerceProject.API.Dtos;
using EcommerceProject.Domain.AggregatesRoot.ProductAggregate;
using EcommerceProject.Infrastructure.CQRS.Command;
using EcommerceSystem.Spec.Products.API;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.Spec.Products.StepDefinitions
{
    public class GetProductsStepDefinition
    {
        private readonly ProductApi _productApi;
        private readonly GetProductsRequest _request;
        private IEnumerable<Product> _products;
        public GetProductsStepDefinition(ProductApi productApi, GetProductsRequest request)
        {
            _productApi = productApi;
            _request = request;
        }

        [Given("the name is (.*)")]
        public void GivenTheNaneIs(string name)
        {
            _request.Name = name;
        }

        [Given("the trademark is (.*)")]
        public void GivenTheTradeMarkIs(string trademark)
        {
            _request.TradeMark = trademark;
        }

        [Given("the origin is (.*)")]
        public void GivenTheOriginIs(string origin)
        {
            _request.Origin = origin;
        }

        [Given("the currency is (.*)")]
        public void GivenTheCurrencyIs(string currency)
        {
            _request.Currency = currency;
        }

        [Given("the max value is (.*)")]
        public void GivenMaxValueIs(decimal maxValue)
        {
            _request.MaxValue = maxValue;
        }

        [Given("the min value is (.*)")]
        public void GivenMinValueIs(decimal minValue)
        {
            _request.MinValue = minValue;
        }

        [When("the products list is provided")]
        public async Task WhenTheProductsListIsProvided()
        {
            var actionResult = await _productApi.GetProducts(_request);
            var okObjectResult = actionResult as OkObjectResult;
            _products = okObjectResult.Value as IEnumerable<Product>;
        }

        public void ThenTheProductCountShouldBe(IEnumerable<Product> result)
        {
            _products.Should().BeSameAs(result);
        }
    }
}
