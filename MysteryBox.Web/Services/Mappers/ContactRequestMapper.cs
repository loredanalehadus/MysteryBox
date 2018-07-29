using Microsoft.Extensions.Configuration;
using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Request;

namespace MysteryBox.WebService.Services.Mappers
{
    public class ContactRequestMapper : IContactRequestMapper
    {
        private readonly string _reseller;
        private readonly string _username;
        private readonly string _password;

        public ContactRequestMapper(IConfiguration configuration)
        {
            _reseller = configuration["Domainbox:Reseller"];
            _username = configuration["Domainbox:Username"];
            _password = configuration["Domainbox:Password"];
        }

        public CreateContactRequest ToCreateContact(ContactRequest contactRequest)
        {
            return new CreateContactRequest
            {
                Body = new EnvelopeBody
                {
                    CreateContact = new CreateContact
                    {
                        AuthenticationParameters = new AuthenticationParameters
                        {
                            Reseller = _reseller,
                            Username = _username,
                            Password = _password
                        },
                        CommandParameters = new CommandParameters
                        {
                            LaunchPhase = contactRequest.LaunchPhase,
                            TLD = contactRequest.TLD,
                            Contact = new CreateContactCommandParametersContact
                            {
                                City = contactRequest.Contact.City,
                                CountryCode = contactRequest.Contact.CountryCode,
                                Email = contactRequest.Contact.Email,
                                Fax = contactRequest.Contact.Fax,
                                Name = contactRequest.Contact.Name,
                                Organisation = contactRequest.Contact.Organisation,
                                Postcode = contactRequest.Contact.Postcode,
                                State = contactRequest.Contact.State,
                                Street1 = contactRequest.Contact.Street1,
                                Street2 = contactRequest.Contact.Street2,
                                Street3 = contactRequest.Contact.Street3,
                                Telephone = contactRequest.Contact.Telephone,
                                TelephoneExtension = contactRequest.Contact.TelephoneExtension
                            }
                        }
                    }
                }
            };
        }

        public ModifyContactRequest ToModifyContact(ContactRequest contactRequest, int contactId)
        {
            return new ModifyContactRequest
            {
                Body = new ModifyContactRequestEnvelopeBody
                {
                    ModifyContact = new ModifyContact
                    {
                        AuthenticationParameters = new ModifyContactAuthenticationParameters
                        {
                            Username = _username,
                            Password = _password,
                            Reseller = _reseller
                        },
                        CommandParameters = new ModifyContactCommandParameters
                        {
                            ContactId = contactId,
                            Contact = new ModifyContactCommandParametersContact
                            {
                                City = contactRequest.Contact.City,
                                CountryCode = contactRequest.Contact.CountryCode,
                                Email = contactRequest.Contact.Email,
                                Fax = contactRequest.Contact.Fax,
                                Name = contactRequest.Contact.Name,
                                Organisation = contactRequest.Contact.Organisation,
                                Postcode = contactRequest.Contact.Postcode,
                                State = contactRequest.Contact.State,
                                Street1 = contactRequest.Contact.Street1,
                                Street2 = contactRequest.Contact.Street2,
                                Street3 = contactRequest.Contact.Street3,
                                Telephone = contactRequest.Contact.Telephone,
                                TelephoneExtension = contactRequest.Contact.TelephoneExtension
                            }
                        }
                    }
                }
            };
        }

        public QueryContactRequest ToQueryContact(int contactId)
        {
            return new QueryContactRequest
            {
                Body = new QueryContactRequestEnvelopeBody
                {
                    QueryContact = new QueryContact
                    {
                        AuthenticationParameters = new QueryContactAuthenticationParameters
                        {
                            Username = _username,
                            Password = _password,
                            Reseller = _reseller
                        },
                        CommandParameters = new QueryContactCommandParameters
                        {
                            ContactId = contactId
                        }
                    }
                }
            };
        }

        public DeleteContactRequest ToDeleteContact(int contactId)
        {
            return new DeleteContactRequest
            {
                Body = new DeleteContactRequestEnvelopeBody
                {
                    DeleteContact = new DeleteContact
                    {
                        AuthenticationParameters = new DeleteContactAuthenticationParameters
                        {
                            Username = _username,
                            Password = _password,
                            Reseller = _reseller
                        },
                        CommandParameters = new DeleteContactCommandParameters
                        {
                            ContactId = contactId
                        }
                    }
                }
            };
        }
    }
}