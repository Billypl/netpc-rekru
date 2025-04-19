using ContactsAPI.Models.DTOs;
using ContactsAPI.Models.Entities;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetById([FromRoute] int id)
        {
            var contact = _contactService.GetById(id);
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ContactCreateDto dto)
        {
            int contactId = _contactService.Add(dto);
            return Created($"/api/contacts/{contactId}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] ContactUpdateDto dto)
        {
            _contactService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _contactService.Delete(id);
            return NoContent();
        }
    }
}