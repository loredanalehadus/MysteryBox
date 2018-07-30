using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MysteryBox.WebService.Exceptions;
using MysteryBox.WebService.Models.Domainbox.Response;
using MysteryBox.WebService.Services.Common;

namespace MysteryBox.WebService.Services.ExternalServiceClient
{
    public class DomainboxServiceClient : IDomainboxServiceClient
    {
        private readonly IXmlService _xmlService;
        private readonly ILogger<DomainboxServiceClient> _logger;
        private readonly string _url;

        public DomainboxServiceClient(IConfiguration configuration, IXmlService xmlService, ILogger<DomainboxServiceClient> logger)
        {
            _xmlService = xmlService;
            _url = configuration["Domainbox:Url"];
            _logger = logger;
        }

        public async Task<T> RequestSoapAction<T>(string payload) where T : class
        {
            var response = await new HttpRequestBuilder()
                .WithRequestUri(_url)
                .WithPayload(payload, "text/xml")
                .WithHttpMethod(HttpMethod.Post)
                .WithHttpRequestHeaders(new Dictionary<string, string> { { "SOAPAction", GetSoapActionName<T>() } })
                .SendWithXmlResponse();

            _logger.LogInformation("Domainbox responded with 200 OK", response);

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
            {typeof(CreateContactResponse), "CreateContact" },
            {typeof(ModifyContactResponse), "ModifyContact" },
            {typeof(QueryContactResponse), "QueryContact" },
            {typeof(DeleteContactResponse), "DeleteContact" }
        };
    }
}
