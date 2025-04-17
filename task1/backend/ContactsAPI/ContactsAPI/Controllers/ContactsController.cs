using ContactsAPI.Models.Entities;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}