using System.Threading.Tasks;

namespace MysteryBox.WebService.Services.ExternalServiceClient
{
    public interface IDomainboxServiceClient
    {
        Task<string> RequestSoapAction<T>(string payload) where T : class;
    }
}
