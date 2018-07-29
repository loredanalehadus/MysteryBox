using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Response;

namespace MysteryBox.WebService.Services.Mappers
{
    public interface IContactResponseMapper
    {
        ContactResponse From(CreateContactResponse createContactResponse);
        ContactDetailsResponse From(QueryContactResponse queryContactResponse);
    }
}