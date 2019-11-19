using ApiNET.Models;
using ApiNET.Services;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class CustomerController
        : ApiControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IValidator<CustomerCreate> customerCreateValidator;
        private readonly ICacheService cacheService;

        private readonly IAddressService addressService;
        private readonly IPhoneService phoneService;
        private readonly IEmailService emailService;

        public CustomerController(
            ICustomerService customerService,
            IValidator<CustomerCreate> customerCreateValidator,
            ICacheService cacheService,
            IAddressService addressService,
            IPhoneService phoneService,
            IEmailService emailService)
        {
            this.customerService = customerService;
            this.customerCreateValidator = customerCreateValidator;
            this.cacheService = cacheService;
            this.addressService = addressService;
            this.emailService = emailService;
            this.phoneService = phoneService;
        }

        [HttpGet]
        [HttpHead]
        public IActionResult Get()
        {
            var customers = cacheService.Get<List<Customer>>("CustomerList");
            if (customers == null)
            {
                var list = customerService.GetCustomers();
                cacheService.Add<List<Customer>>("CustomerList", list);
                return Ok(list);
            }
            else
            {
                return Ok(customers);
            }
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] CustomerCreate customerCreate)
        {
            if (customerCreate == null)
            {
                return BadRequest();
            }

            // Attribute-Based Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Custom and Method Validations
            var validationResult = customerCreateValidator.Validate(customerCreate);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument<CustomerUpdate> patch)
        {
            var customer = customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // input mapping
            CustomerUpdate customerUpdate = new CustomerUpdate();
            customerUpdate.Age = customer.Age;
            customerUpdate.Name = customer.Name;
            customerUpdate.SurName = customer.SurName;
            customerUpdate.CustomerRank = customer.CustomerRank;

            // PATCH operations apply
            patch.ApplyTo(customerUpdate);

            // output mapping
            customer.Age = customerUpdate.Age;
            customer.Name = customerUpdate.Name;
            customer.SurName = customerUpdate.SurName;
            customer.CustomerRank = customerUpdate.CustomerRank;

            // update action
            customerService.UpdateCustomer(customer);

            return Ok();
        }
    }
}