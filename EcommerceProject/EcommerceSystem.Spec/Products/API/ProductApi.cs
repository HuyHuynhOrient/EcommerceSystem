using EcommerceProject.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace EcommerceSystem.Spec.Products.API
{
    public class ProductApi
    {
        private readonly RestClient _client;
        public ProductApi()
        {
            _client = new RestClient("https://localhost:7241/api/products");
        }

        public async Task<IActionResult> GetProducts(GetProductsRequest obj) 
        {
            var request = new RestRequest("").AddObject(obj);

            var response = await _client.GetAsync<Task<IActionResult>>(request);

            return response.Result;
        }

        public async Task<IActionResult> GetProductDetails(int productId) 
        {
            
            var request = new RestRequest($"{productId}");

            var response = await _client.GetAsync<Task<IActionResult>>(request);

            return response.Result;
        }

        public async Task<IActionResult> CreateProduct(CreateProductRequest obj) 
        {
            var request = new RestRequest("").AddObject(obj);

            var response = await _client.GetAsync<Task<IActionResult>>(request);

            return response.Result;
        }

        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductRequest obj) 
        {
            var request = new RestRequest($"{productId}").AddObject(obj);

            var response = await _client.GetAsync<Task<IActionResult>>(request);

            return response.Result;
        }

        public async Task<IActionResult> DeleteProduct(int productId) 
        {
            var request = new RestRequest($"{productId}").AddObject(this);

            var response = await _client.GetAsync<Task<IActionResult>>(request);

            return response.Result;
        }
    }
}
