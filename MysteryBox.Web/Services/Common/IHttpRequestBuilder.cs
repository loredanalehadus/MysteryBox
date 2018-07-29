using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MysteryBox.WebService.Services.Common
{
    public interface IHttpRequestBuilder
    {
        IHttpRequestBuilder WithPayload(string payload, string contentType);
        IHttpRequestBuilder WithHttpMethod(HttpMethod httpMethod);
        IHttpRequestBuilder WithHttpRequestHeaders(Dictionary<string, string> httpRequestHeaders);
        IHttpRequestBuilder WithRequestUri(string url);
        Task<string> SendWithXmlResponse();
    }
}
