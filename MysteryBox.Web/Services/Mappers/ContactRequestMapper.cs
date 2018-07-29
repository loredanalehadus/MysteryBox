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

        public CreateContactRequest From(ContactRequest contactRequest)
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
                            Contact = new Contact
                            {
                                City = contactRequest.City,
                                CountryCode = contactRequest.CountryCode,
                                Email = contactRequest.Email,
                                Fax = contactRequest.Fax,
                                Name = contactRequest.Name,
                                Organisation = contactRequest.Organisation,
                                Postcode = contactRequest.PostCode,
                                State = contactRequest.State,
                                Street1 = contactRequest.Street1,
                                Street2 = contactRequest.Street2,
                                Street3 = contactRequest.Street3,
                                Telephone = contactRequest.Telephone,
                                TelephoneExtension = contactRequest.TelephoneExtension
                            }
                        }
                    }
                }
            };
        }

        public ModifyContactRequest From(ContactRequest contactRequest, int contactId)
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
                                City = contactRequest.City,
                                CountryCode = contactRequest.CountryCode,
                                Email = contactRequest.Email,
                                Fax = contactRequest.Fax,
                                Name = contactRequest.Name,
                                Organisation = contactRequest.Organisation,
                                Postcode = contactRequest.PostCode,
                                State = contactRequest.State,
                                Street1 = contactRequest.Street1,
                                Street2 = contactRequest.Street2,
                                Street3 = contactRequest.Street3,
                                Telephone = contactRequest.Telephone,
                                TelephoneExtension = contactRequest.TelephoneExtension
                            }
                        }
                    }
                }
            };
        }
    }
}