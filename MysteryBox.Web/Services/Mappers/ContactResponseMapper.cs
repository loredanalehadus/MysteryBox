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
                TLDs = createContactResponse.Body.Response.Result.TLDs,
                ResultCode = createContactResponse.Body.Response.Result.ResultCode,
                ResultMessage = createContactResponse.Body.Response.Result.ResultMsg
            };
        }

        public ContactDetailsResponse From(QueryContactResponse queryContactResponse)
        {
            var queryContact = queryContactResponse.Body.Response.Result.Contact;

            return new ContactDetailsResponse
            {
                Id = queryContact?.ContactId,
                TLDs = queryContactResponse.Body.Response.Result.TLDs,
                ResultCode = queryContactResponse.Body.Response.Result.ResultCode,
                ResultMessage = queryContactResponse.Body.Response.Result.ResultMsg,
                Contact = queryContact != null ? new Contact
                {
                    City = queryContact.City,
                    CountryCode = queryContact.CountryCode,
                    Email = queryContact.Email,
                    Fax = queryContact.Fax,
                    Name = queryContact.Name,
                    Organisation = queryContact.Organisation,
                    Postcode = queryContact.Postcode,
                    State = queryContact.State,
                    Street1 = queryContact.Street1,
                    Street2 = queryContact.Street2,
                    Street3 = queryContact.Street3,
                    Telephone = queryContact.Telephone,
                    TelephoneExtension = queryContact.TelephoneExtension,
                    CustomerId = queryContact.CustomerId
                }
                :null,
                Linked = queryContactResponse.Body.Response.Result.Linked
            };
        }

        public ContactResponse From(DeleteContactResponse deleteContactResponse, int contactId)
        {
            var result = deleteContactResponse.Body.Response.DeleteContactResult;
            return new ContactResponse
            {
                Id = contactId,
                ResultCode = result.ResultCode,
                ResultMessage = result.ResultMsg,
                TLDs = null
            };
        }
    }
}