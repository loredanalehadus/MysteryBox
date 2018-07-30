using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MysteryBox.WebService.Models;
using MysteryBox.WebService.Services;
using MysteryBox.WebService.Services.Common;

namespace MysteryBox.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ILoggingService<ContactController> _loggingService;

        public ContactController(IContactService contactService, ILoggingService<ContactController> loggingService)
        {
            _contactService = contactService;
            _loggingService = loggingService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContactRequest contactRequest)
        {
            _loggingService.LogInformation("Requesting create contact...", contactRequest);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                _loggingService.LogWarning("Invalid model state for new contact request", errors);
                return BadRequest(errors);
            }

            var response = await _contactService.Create(contactRequest);
            _loggingService.LogInformation("Contact with '{ID}' successfully created.", response.Id);

            return Ok(response);
        }

        [HttpPut("{contactId}")]
        public async Task<IActionResult> Put(int contactId, [FromBody]ContactRequest contactRequest)
        {
            _loggingService.LogInformation("Requesting modify contact '{ID}'...", contactId);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                _loggingService.LogWarning("Invalid model state for new contact request", errors);
                return BadRequest(errors);
            }

            await _contactService.Modify(contactId, contactRequest);

            _loggingService.LogInformation("Contact with '{ID}' successfully modified.", contactId);

            return Ok();
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(int contactId)
        {
            _loggingService.LogInformation("Querying contact details for '{ID}'...", contactId);

            var response = await _contactService.Get(contactId);

            if (response.HasError)
            {

                _loggingService.LogError($"Cannot retrieve details for contact ID '{contactId}': {response.ResultMessage}");
                return BadRequest(response.ResultMessage);
            }

            _loggingService.LogInformation("Successfully retrieved contact details", response);
            return Ok(response);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            _loggingService.LogInformation("Deleting contact '{ID}'...", contactId);
            var response = await _contactService.Delete(contactId);

            if (response.HasError)
            {
                _loggingService.LogError($"Cannot delete contact '{contactId}': {response.ResultMessage}");
                return BadRequest(response.ResultMessage);
            }

            _loggingService.LogInformation("Successfully deleted contact '{ID}'", contactId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int offset = 0, int limit = 2)
        {
            return Ok(Contacts.StoredContacts.Skip(offset).Take(limit));
        }
    }
}