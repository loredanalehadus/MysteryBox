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
        private readonly IXmlService _xmlService;
        private readonly ILoggingService<DomainboxServiceClient> _loggingService;
        private readonly string _url;

        public DomainboxServiceClient(IConfiguration configuration, IXmlService xmlService, ILoggingService<DomainboxServiceClient> loggingService)
        {
            _xmlService = xmlService;
            _url = configuration["Domainbox:Url"];
            _loggingService = loggingService;
        }

        public async Task<T> RequestSoapAction<T>(string payload) where T : class
        {
            var soapActionName = GetSoapActionName<T>();
            _loggingService.LogInformation($"Requesting SOAP action '{soapActionName}' with payload {payload}");

            var response = await new HttpRequestBuilder()
                .WithRequestUri(_url)
                .WithPayload(payload, "text/xml")
                .WithHttpMethod(HttpMethod.Post)
                .WithHttpRequestHeaders(new Dictionary<string, string> { { "SOAPAction", soapActionName } })
                .SendWithXmlResponse();

            _loggingService.LogInformation($"SOAP action '{soapActionName}' response with payload: {response}");

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
