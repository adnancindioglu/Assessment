using AutoMapper;
using Contact.API.Infrastructure;
using Contact.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _contactService = ContactService;
            _mapper = mapper;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contacts = await _contactService.Get();
            var contactModel = _mapper.Map<IEnumerable<ContactModel>>(contacts);
            return Ok(contactModel);
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(Guid contactId)
        {
            var contact = await _contactService.Get(contactId);
            if (contact == null)
            {
                return NotFound("Contact not found");
            }
            var contactModel = _mapper.Map<ContactModel>(contact);
            return Ok(contactModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = _mapper.Map<ContactModel>(contactModel);
            await _contactService.Create(contact);
            contactModel = _mapper.Map<ContactModel>(contact);
            return CreatedAtAction(nameof(Get), new { ContactId = contactModel.ContactId }, contactModel);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(Guid contactId)
        {
            if (await _contactService.Validate(contactId) == false)
            {
                return NotFound("Contact not found");
            }

            await _contactService.Delete(contactId);
            return NoContent();
        }
    }
}
