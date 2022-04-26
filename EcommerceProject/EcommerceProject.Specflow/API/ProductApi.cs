using EcommerceProject.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Specflow.API
{
    public class ProductApi
    {
        //private readonly RestClient _client;

        //public ProductApi()
        //{
        //    _client = new RestClient("http://localhost:7241/api/products");

        //    //ServicePointManager.ServerCertificateValidationCallback +=
        //    //    (sender, cert, chain, sslPolicyErrors) => true;
        //}
        
        //public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        //{
        //    var restRequest = new RestRequest("", Method.Post).AddObject(request);

        //    var response = await _client.GetAsync<IActionResult>(restRequest);

        //    return response;
        //}
    }
}
