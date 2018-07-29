using System.Linq;
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                return BadRequest(errors);
            }

            var response = await _contactService.Create(contactRequest);
            return Ok(response);
        }

        [HttpPut("{contactId}")]
        public async Task<IActionResult> Put(int contactId, [FromBody]ContactRequest contactRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                return BadRequest(errors);
            }

            await _contactService.Modify(contactId, contactRequest);
            return Ok();
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(int contactId)
        {
            var response = await _contactService.Get(contactId);

            if (response.HasError)
            {
                return BadRequest(response.ResultMessage);
            }

            return Ok(response);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            var response = await _contactService.Delete(contactId);

            if (response.HasError)
            {
                return BadRequest(response.ResultMessage);
            }

            return Ok();
        }
    }
}