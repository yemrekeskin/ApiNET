using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiNET.Controllers
{
    public partial class ExampleController
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