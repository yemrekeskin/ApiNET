using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiNET.Models;
using ApiNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiVersion("2.0")]
    public class ExternalController 
        : ApiControllerBase
    {
        private readonly IApiService apiService;
        public ExternalController(
            IApiService apiService)
        {
            this.apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            string endpoint = "https://restcountries.eu/rest/v2/all";

            var result = await apiService.InvokeGet<List<Countries>>(endpoint);
            return Ok(result);
        }

        //[HttpPost]        
        //public async Task<IActionResult> GetBsonDataAsync()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44339/");

        //        // Set the Accept header for BSON.
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

        //        CustomerCreate customerCreate = new CustomerCreate()
        //        {
        //            Name = "New Customer",
        //            SurName = "Surname",
        //            CustomerRank = CustomerRank.Bronze,
        //            Age = 15
        //        };

        //        // GET using the BSON formatter.
        //        MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
        //        var result = await client.PostAsync("api/v1/customer", customerCreate, bsonFormatter);

        //        result.EnsureSuccessStatusCode();
        //    }
        //    return Ok();
        //}
    }
}