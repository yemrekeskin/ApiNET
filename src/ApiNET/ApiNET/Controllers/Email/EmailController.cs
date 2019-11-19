using ApiNET.Models;
using ApiNET.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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