using EcommerceProject.API;
using EcommerceProject.Specflow.Core;
using EcommerceProject.Specflow.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace EcommerceProject.Specflow.StepDefinitions
{
    [Binding]
    internal class ProductStepDefinitions : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly ScenarioContext _scenarioContext;
        private HttpResponseMessage _response;
        private int _productId;
        public ProductStepDefinitions(CustomWebApplicationFactory<Startup> factory, ScenarioContext scenarioContext)
        {
            _client = factory.CreateClient();
            _scenarioContext = scenarioContext;
        }

        [Given(@"Product id is (.*)")]
        public void GivenProductIdIs(int productId)
        {
            _productId = productId;
        }

        [When(@"Customer want to get product details")]
        public async Task WhenCustomerWantToGetProductDetails()
        {
            _response = await _client.GetAsync($"/api/products/{_productId}");
        }

        [Then(@"The product repository should return status is (.*)")]
        public void ThenTheProductRepositoryShouldReturnStatusIs(string statuscode)
        {
            _response.StatusCode.ToString().Should().Be(statuscode);
        }

        [Then(@"The product repository should return product data:")]
        public void ThenTheProductRepositoryShouldReturnProductData(Table table)
        {
            var row = table.Rows.First();
            var expectedProduct = new Product(row[1], new MoneyValue(Convert.ToDecimal(row[2]), row[3]), row[4], row[5], row[6]);
            expectedProduct.Id = Convert.ToInt32(row[0]);

            var result = _response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<Product>(result);

            product.Id.Should().Be(expectedProduct.Id);
            product.Name.Should().Be(expectedProduct.Name);
            product.Price.Value.Should().Be(expectedProduct.Price.Value);
            product.Price.Currency.Should().Be(expectedProduct.Price.Currency);
            product.Origin.Should().Be(expectedProduct.Origin);
            product.TradeMark.Should().Be(expectedProduct.TradeMark);
            product.Discription.Should().Be(expectedProduct.Discription);
        }

        [When(@"get all product in the product repository")]
        public async Task WhenGetAllProductInTheProductRepository()
        {
            _response = await _client.GetAsync("/api/products");
        }

        [Then(@"the product repository should contain the following products:")]
        public void ThenTheProductRepositoryShouldContainTheFollowingProducts(Table table)
        {
            var expectedProducts = new List<Product>();
            foreach(var row in table.Rows)
            {
                var product = new Product(row[1], new MoneyValue(Convert.ToDecimal(row[2]), row[3]), row[4], row[5], row[6]);
                product.Id = Convert.ToInt32(row[0]);
                expectedProducts.Add(product);
            }

            var result = _response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(result);

            products.Count.Should().Be(expectedProducts.Count);
        }
    }
}
