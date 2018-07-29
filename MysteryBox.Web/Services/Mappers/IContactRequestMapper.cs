using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Request;

namespace MysteryBox.WebService.Services.Mappers
{
    public interface IContactRequestMapper
    {
        CreateContactRequest ToCreateContact(ContactRequest contactRequest);
        ModifyContactRequest ToModifyContact(ContactRequest contactRequest, int contactId);
        QueryContactRequest ToQueryContact(int contactId);
        DeleteContactRequest ToDeleteContact(int contactId);
    }
}