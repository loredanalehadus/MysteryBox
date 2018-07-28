using System.Threading.Tasks;
using MysteryBox.WebService.Models;

namespace MysteryBox.WebService.Services
{
    public interface IContactService
    {
        Task<ContactResponse> Create(ContactRequest contactRequest);
    }
}
