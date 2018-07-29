﻿using System.Threading.Tasks;
using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Response;
using MysteryBox.WebService.Services.Common;
using MysteryBox.WebService.Services.ExternalServiceClient;
using MysteryBox.WebService.Services.Mappers;

namespace MysteryBox.WebService.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRequestMapper _requestMapper;
        private readonly IXmlService _xmlService;
        private readonly IDomainboxServiceClient _domainboxServiceClient;
        private readonly IContactResponseMapper _responseMapper;

        public ContactService(IContactRequestMapper mapper, IXmlService xmlService, IDomainboxServiceClient domainboxServiceClient, IContactResponseMapper responseMapper)
        {
            _requestMapper = mapper;
            _xmlService = xmlService;
            _domainboxServiceClient = domainboxServiceClient;
            _responseMapper = responseMapper;
        }

        public async Task<ContactResponse> Create(ContactRequest contactRequest)
        {
            var createContactRequest = _requestMapper.From(contactRequest);
            var requestPayload = _xmlService.Serialize(createContactRequest);
            var createContactResponse = await _domainboxServiceClient.RequestSoapAction<CreateContactResponse>(requestPayload);
            return _responseMapper.From(createContactResponse);
        }

        public async Task Modify(int contactId, ContactRequest contactRequest)
        {
            var modifyContactRequest = _requestMapper.From(contactRequest, contactId);
            var requestPayload = _xmlService.Serialize(modifyContactRequest);
            await _domainboxServiceClient.RequestSoapAction<ModifyContactResponse>(requestPayload);
        }

        public async Task<ContactResponse> Get(int contactId)
        {
            var queryContactRequest = _requestMapper.From(contactId);
            var requestPayload = _xmlService.Serialize(queryContactRequest);
            var queryContactResponse = await _domainboxServiceClient.RequestSoapAction<QueryContactResponse>(requestPayload);
            return _responseMapper.From(queryContactResponse);
        }
    }
}