using ApiNET.Attribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiNET.Controllers.Example
{
    public class CacheController
        : ApiControllerBase
    {
        [AllowAnonymous]
        [Route("GetData")]
        [CacheFilter(TimeDuration = 100)]
        [HttpGet]
        public IActionResult GetData()
        {
            Dictionary<object, object> obj = new Dictionary<object, object>
            {
                { "1", "Punjab" },
                { "2", "Assam" },
                { "3", "UP" },
                { "4", "AP" },
                { "5", "J&K" },
                { "6", "Odisha" },
                { "7", "Delhi" },
                { "9", "Karnataka" },
                { "10", "Bangalore" },
                { "21", "Rajesthan" },
                { "31", "Jharkhand" },
                { "41", "chennai" },
                { "51", "jammu" },
                { "61", "Bhubaneshwar" },
                { "71", "Delhi" },
                { "19", "Karnataka" }
            };
            return Ok(obj);
        }
    }
}