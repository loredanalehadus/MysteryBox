using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MysteryBox.WebService.Models;
using MysteryBox.WebService.Services;

namespace MysteryBox.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContactRequest contactRequest)
        {
            _logger.LogInformation("Requesting creation of new contact", contactRequest);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);

                _logger.LogWarning("Invalid model state for new contact request", errors);
                return BadRequest(errors);
            }

            var response = await _contactService.Create(contactRequest);
            _logger.LogInformation("Contact with {ID} created", response.Id);

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