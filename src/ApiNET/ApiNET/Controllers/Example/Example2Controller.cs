using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiNET.Controllers
{
    public partial class ExampleController
        : ApiControllerBase
    {
        [HttpGet]
        [Route("persons")]
        public ActionResult<PagedList<Person>> Get([FromQuery] FilterModel filter)
        {
            //Filtering logic
            Func<FilterModel, IEnumerable<Person>> filterData = (filterModel) =>
            {
                return persons.Where(p => p.Name.StartsWith(filterModel.Term ?? String.Empty, StringComparison.InvariantCultureIgnoreCase))
                .Skip((filterModel.Page - 1) * filter.Limit)
                .Take(filterModel.Limit);
            };

            //Get the data for the current page
            var result = new PagedList<Person>();
            result.Items = filterData(filter);

            //Get next page URL string
            FilterModel nextFilter = filter.Clone() as FilterModel;
            nextFilter.Page += 1;
            String nextUrl = filterData(nextFilter).Count() <= 0 ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);

            //Get previous page URL string
            FilterModel previousFilter = filter.Clone() as FilterModel;
            previousFilter.Page -= 1;
            String previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

            result.NextPage = !String.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
            result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;

            return result;
        }

        private IEnumerable<Person> persons = new List<Person>()
        {
            new Person() { Name = "Nancy Davolio", BirthDate = DateTime.Parse("1948-12-08"), Email = "nancy.davolio@test.com" },
            new Person() { Name = "Andrew Fuller", BirthDate = DateTime.Parse("1952-02-19"), Email = "andrew.fuller@test.com" },
            new Person() { Name = "Janet Leverling", BirthDate = DateTime.Parse("1963-08-30"), Email = "janet.leverling@test.com" },
            new Person() { Name = "Margaret Peacock", BirthDate = DateTime.Parse("1937-09-19"), Email = "margaret.peacock@test.com" },
            new Person() { Name = "Steven Buchanan", BirthDate = DateTime.Parse("1955-03-04"), Email = "steven.buchanan@test.com" },
            new Person() { Name = "Michael Suyama", BirthDate = DateTime.Parse("1963-07-02"), Email = "michael.suyama@test.com" },
            new Person() { Name = "Robert King", BirthDate = DateTime.Parse("1960-05-29"), Email = "robert.king@test.com" },
            new Person() { Name = "Laura Callahan", BirthDate = DateTime.Parse("1958-01-09"), Email = "laura.callahan@test.com" },
            new Person() { Name = "Anne Dodsworth", BirthDate = DateTime.Parse("1966-01-27"), Email = "anne.dodsworth@test.com" }
        };
    }
}