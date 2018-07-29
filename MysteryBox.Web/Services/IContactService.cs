using System.Threading.Tasks;
using MysteryBox.WebService.Models;

namespace MysteryBox.WebService.Services
{
    public interface IContactService
    {
        Task<ContactResponse> Create(ContactRequest contactRequest);
        Task Modify(int contactId, ContactRequest contactRequest);
        Task<ContactResponse> Get(int contactId);
        Task<ContactResponse> Delete(int contactId);
    }
}
