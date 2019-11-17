using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers.Samples
{
    public class ExampleController 
        : ApiControllerBase
    {
        [HttpGet]
        [Route("data.csv")]
        [Produces("text/csv")]
        public IActionResult GetDataAsCsv()
        {
            return Ok(DummyDataList());
        }

        [HttpGet]
        [Route("data.txt")]
        [Produces("text/csv")]
        public IActionResult GetDataAsText()
        {
            return Ok(DummyDataList());
        }

        private static IEnumerable<LocalizationRecord> DummyDataList()
        {
            var model = new List<LocalizationRecord>
            {
                new LocalizationRecord
                {
                    Id = 1,
                    Key = "test",
                    Text = "test text",
                    LocalizationCulture = "en-US",
                    ResourceKey = "test",
                    ResourceValue = "test value"

                },
                new LocalizationRecord
                {
                    Id = 2,
                    Key = "test",
                    Text = "test2 text de-CH",
                    LocalizationCulture = "de-CH",
                    ResourceKey = "test",
                    ResourceValue = "test value"
                }
            };

            return model;
        }
    }
}