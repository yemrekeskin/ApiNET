using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}