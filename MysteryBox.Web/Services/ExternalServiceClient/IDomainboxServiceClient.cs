using System.Threading.Tasks;

namespace MysteryBox.WebService.Services.ExternalServiceClient
{
    public interface IDomainboxServiceClient
    {
        Task<T> RequestSoapAction<T>(string payload) where T : class;
    }
}
