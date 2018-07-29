using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MysteryBox.WebService.Models;
using MysteryBox.WebService.Services;

namespace MysteryBox.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContactRequest contactRequest)
        {
            var response = await _contactService.Create(contactRequest);
            return Ok(response);
        }

        [HttpPut("{contactId}")]
        public async Task<IActionResult> Put(int contactId, [FromBody]ContactRequest contactRequest)
        {
            await _contactService.Modify(contactId, contactRequest);
            return Ok();
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(int contactId)
        {
            var response = await _contactService.Get(contactId);
            return Ok(response);
        }
    }
}