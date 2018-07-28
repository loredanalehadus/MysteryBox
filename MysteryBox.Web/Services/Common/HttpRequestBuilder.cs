using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MysteryBox.WebService.Exceptions;

namespace MysteryBox.WebService.Services.Common
{
    public class HttpRequestBuilder : IHttpRequestBuilder
    {
        private readonly HttpClient _httpClient;
        private StringContent _payload;
        private HttpMethod _httpMethod;
        private Dictionary<string, string> _httpRequestHeaders = new Dictionary<string, string>();

        public HttpRequestBuilder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IHttpRequestBuilder WithPayload(string payload, string contentType)
        {
            _payload = new StringContent(payload, Encoding.UTF8, contentType);
            return this;
        }

        public IHttpRequestBuilder WithHttpMethod(HttpMethod httpMethod)
        {
            _httpMethod = httpMethod;
            return this;
        }

        public IHttpRequestBuilder WithHttpRequestHeaders(Dictionary<string, string> httpRequestHeaders)
        {
            foreach (var httpRequestHeader in httpRequestHeaders)
            {
                _httpRequestHeaders.Add(httpRequestHeader.Key, httpRequestHeader.Value);
            }

            return this;
        }

        public async Task<string> SendWithXmlResponse()
        {
            try
            {
                using (var client = _httpClient)
                {
                    var httpRequestMessage = new HttpRequestMessage(_httpMethod, _httpClient.BaseAddress);
                    SetHttpRequestHeaders(_httpRequestHeaders, ref httpRequestMessage);
                    httpRequestMessage.Content = _payload;

                    using (var httpResponseMessage = await client.SendAsync(httpRequestMessage))
                    {
                        return await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw new ServiceClientException(_httpClient.BaseAddress.ToString(), e);
            }
        }

        private static void SetHttpRequestHeaders(Dictionary<string, string> httpRequestHeaders, ref HttpRequestMessage httpRequestMessage)
        {
            if (httpRequestHeaders == null) return;
            foreach (var header in httpRequestHeaders)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }

        public void Dispose()
        {
            _payload?.Dispose();
        }
    }
}