using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHI.ContactsInvetory.BusinessLayer;
using EHI.ContactsInvetory.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EHI.ContactsInvetory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IContactBusinessLayer _contactBusinessLayer = null;

        public ContactController(ILogger<ContactController> logger, IContactBusinessLayer contactBusinessLayer)
        {
            _logger = logger;
            _contactBusinessLayer = contactBusinessLayer;
        }

        // GET api/contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            try
            {
                var contacts = await _contactBusinessLayer.GetContacts();
                return contacts.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return NoContent();
            }
        }

        // GET api/contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            try
            {
                var contact = await _contactBusinessLayer.GetContact(id);

                if (contact == null)
                {
                    return NotFound();
                }

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return NoContent();
            }
        }

        // POST api/contact
        [HttpPost]
        public async Task<ActionResult<Contact>> Post([FromBody] Contact contact)
        {
            try
            {
                await _contactBusinessLayer.AddContact(contact);
                return CreatedAtAction("Get", new { id = contact.Id }, contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return NoContent();
            }
        }

        // PUT api/contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            try
            {
                if (id != contact.Id)
                {
                    return BadRequest();
                }
                await _contactBusinessLayer.UpdateContact(contact);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return NoContent();
            }
        }

        // DELETE api/contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _contactBusinessLayer.DeleteContact(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return NoContent();
            }
        }
    }
}
