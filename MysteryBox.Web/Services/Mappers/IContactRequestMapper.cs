using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Request;

namespace MysteryBox.WebService.Services.Mappers
{
    public interface IContactRequestMapper
    {
        CreateContactRequest From(ContactRequest contactRequest);
        ModifyContactRequest From(ContactRequest contactRequest, int contactId);
    }
}