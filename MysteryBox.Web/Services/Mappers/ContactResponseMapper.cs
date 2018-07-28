using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Response;

namespace MysteryBox.WebService.Services.Mappers
{
    public class ContactResponseMapper : IContactResponseMapper
    {
        public ContactResponse From(CreateContactResponse createContactResponse)
        {
            return new ContactResponse
            {
                Id = createContactResponse.Body.Response.Result.ContactId,
                TLDs = createContactResponse.Body.Response.Result.TLDs
            };
        }
    }
}