using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MysteryBox.WebService.Exceptions;
using MysteryBox.WebService.Models.Domainbox.Response;
using MysteryBox.WebService.Services.Common;

namespace MysteryBox.WebService.Services.ExternalServiceClient
{
    public class DomainboxServiceClient : IDomainboxServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IXmlService _xmlService;

        public DomainboxServiceClient(IConfiguration configuration, IXmlService xmlService)
        {
            _xmlService = xmlService;
            _httpClient = new HttpClient { BaseAddress = new Uri(configuration["Domainbox:Url"]) };
        }

        public async Task<T> RequestSoapAction<T>(string payload) where T : class
        {
            var response = await _httpClient.HttpRequestBuilder()
                .WithPayload(payload, "text/xml")
                .WithHttpMethod(HttpMethod.Post)
                .WithHttpRequestHeaders(new Dictionary<string, string> { { "SOAPAction", GetSoapActionName<T>() } })
               .SendWithXmlResponse();

            return _xmlService.DeserializeXml<T>(response);
        }

        private string GetSoapActionName<T>() where T : class
        {
            var type = typeof(T);
            if (_soapActionsByType.ContainsKey(type))
            {
                return _soapActionsByType[type];
            }

            throw new SoapActionNotSupportedException(type);
        }

        private readonly Dictionary<Type, string> _soapActionsByType = new Dictionary<Type, string>
        {
            {typeof(CreateContactResponse), "CreateContact" }
        };
    }
}
