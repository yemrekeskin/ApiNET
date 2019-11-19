using ApiNET.Binder;
using ApiNET.Models;
using ApiNET.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class CustomerBulkController
        : ApiControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerBulkController(
            ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<CustomerItem> customerItems)
        {
            if (customerItems == null)
            {
                return BadRequest();
            }

            foreach (var customerItem in customerItems)
            {
                // mapping
                Customer customer = new Customer()
                {
                    Name = customerItem.Name,
                    SurName = customerItem.SurName,
                    Age = customerItem.Age,
                    CustomerRank = customerItem.CustomerRank,
                    // System details
                    CreateUser = "SERVICE",
                    DateCreated = DateTime.Now,
                    ModifyUser = "SERVICE",
                    DateModified = DateTime.Now
                };
                // Add action
                customerService.AddCustomer(customer);
            }

            var customerItemsToReturn = customerItems;
            var idsAsString = string.Join(",",
                customerItemsToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetCustomerCollection",
                new { ids = idsAsString },
                customerItemsToReturn);
        }

        [HttpGet("({ids})", Name = "GetCustomerCollection")]
        public IActionResult GetCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<long> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }
            var list = customerService.GetCustomers(ids);
            if (ids.Count() != list.Count())
            {
                return NotFound();
            }
            return Ok(list);
        }
    }
}