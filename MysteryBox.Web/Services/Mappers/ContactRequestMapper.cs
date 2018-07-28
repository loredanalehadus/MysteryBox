using Microsoft.Extensions.Configuration;
using MysteryBox.WebService.Models;
using MysteryBox.WebService.Models.Domainbox.Request;
using EnvelopeBody = MysteryBox.WebService.Models.Domainbox.Request.EnvelopeBody;

namespace MysteryBox.WebService.Services.Mappers
{
    public class ContactRequestMapper : IContactRequestMapper
    {
        private readonly AuthenticationParameters _authenticationParameters;

        public ContactRequestMapper(IConfiguration configuration)
        {
            _authenticationParameters = new AuthenticationParameters
            {
                Reseller = configuration["Domainbox:Reseller"],
                Username = configuration["Domainbox:Username"],
                Password = configuration["Domainbox:Password"]
            };
        }

        public CreateContactRequest From(ContactRequest contactRequest)
        {
            return new CreateContactRequest
            {
                Body = new EnvelopeBody
                {
                    CreateContact = new CreateContact
                    {
                        AuthenticationParameters = _authenticationParameters,
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
    }
}