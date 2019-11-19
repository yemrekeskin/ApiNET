﻿using System;
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
    public class EmailController 
        : ApiControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(
            IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        [HttpHead]
        public IActionResult Get()
        {
            var list = emailService.GetEmail();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetEmail")]
        public IActionResult Get(int id)
        {
            var email = emailService.GetEmailById(id);
            // get action
            if (email == null)
            {
                return NotFound();
            }
            return Ok(email);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var email = emailService.GetEmailById(id);
            // get action
            if (email == null)
            {
                return NotFound();
            }
            // remove action
            this.emailService.DeleteEmail(id);
            return NoContent();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] EmailCreate emailCreate)
        {
            if (emailCreate == null)
            {
                return BadRequest();
            }

            // Attribute-Based Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            // service model convert to model
            Email email = new Email()
            {
                ActivePassive = emailCreate.ActivePassive,
                CustomerId = emailCreate.CustomerId,
                EmailAddress = emailCreate.EmailAddress,
                EmailType = emailCreate.EmailType,
                IsDefault = emailCreate.IsDefault,
                // System details
                IsDeleted = false,
                CreateUser = "SERVICE",
                DateCreated = DateTime.Now,
                ModifyUser = "SERVICE",
                DateModified = DateTime.Now
            };
            // insert action
            emailService.AddEmail(email);

            if (email.Id.Equals(0))
            {
                return StatusCode(500, "Error");
            }

            var result = emailCreate;
            return CreatedAtRoute("GetEmail", new { result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] EmailUpdate emailUpdate)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (emailUpdate == null)
            {
                return BadRequest();
            }

            var email = emailService.GetEmailById(id);
            if (email == null)
            {
                return NotFound();
            }

            try
            {
                // service model convert to entity model
                email.EmailType = emailUpdate.EmailType;
                email.EmailAddress = emailUpdate.EmailAddress;
                email.ActivePassive = emailUpdate.ActivePassive;
                email.CustomerId = emailUpdate.CustomerId;
                email.IsDefault = emailUpdate.IsDefault;
                // System details
                email.DateModified = DateTime.Now;

                // update action
                emailService.UpdateEmail(email);

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