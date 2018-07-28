using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public async Task<IActionResult> CreateContact([FromBody]ContactRequest contactRequest)
        {
            var response = await _contactService.Create(contactRequest);
            return Ok(response);
        }
    }
}