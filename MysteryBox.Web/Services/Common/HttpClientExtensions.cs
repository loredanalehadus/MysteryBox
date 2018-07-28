using System.Net.Http;

namespace MysteryBox.WebService.Services.Common
{
    public static class HttpClientExtensions
    {
        public static IHttpRequestBuilder HttpRequestBuilder(this HttpClient httpClient)
        {
            return new HttpRequestBuilder(httpClient);
        }
    }
}
