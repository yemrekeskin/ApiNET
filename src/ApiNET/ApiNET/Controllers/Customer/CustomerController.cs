using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNET.Models;
using ApiNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class CustomerController 
        : ApiControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = customerService.GetCustomers(); // list action
            // model - service viewmodel mapper operation
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = customerService.GetCustomer(id);
            // get action
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customerService.GetCustomer(id);
            // get action
            if (customer == null)
            {
                return NotFound();
            }
            // remove action
            this.customerService.DeleteCustomer(id);
            return NoContent();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] CustomerCreate customerCreate)
        {
            if (customerCreate == null)
            {
                return BadRequest();
            }

            // service model convert to model
            Customer customer = new Customer()
            {
                Name = customerCreate.Name,
                SurName = customerCreate.SurName,
                Age = customerCreate.Age,
                CustomerRank = customerCreate.CustomerRank,
                // System details
                CreateUser = "SERVICE",
                DateCreated = DateTime.Now,
                ModifyUser = "SERVICE",
                DateModified = DateTime.Now
            };
            // insert action
            customerService.AddCustomer(customer);

            if (customer.Id.Equals(0))
            {
                return StatusCode(500, "Error");
            }

            var result = customerCreate;
            return CreatedAtRoute("GetCustomer", new { result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] CustomerUpdate customerUpdate)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (customerUpdate == null)
            {
                return BadRequest();
            }

            var customer = customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                // service model convert to model
                customer.Name = customerUpdate.Name;
                customer.SurName = customerUpdate.SurName;
                customer.Age = customerUpdate.Age;
                customer.CustomerRank = customerUpdate.CustomerRank;
                // System details
                customer.DateModified = DateTime.Now;

                // update action
                customerService.UpdateCustomer(customer);

                //return Ok();
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}