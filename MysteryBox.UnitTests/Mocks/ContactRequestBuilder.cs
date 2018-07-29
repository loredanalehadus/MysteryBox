using MysteryBox.WebService.Models;

namespace MysteryBox.UnitTests.Mocks
{
    public class ContactRequestBuilder
    {
        private string _telephone = "+44.1234102010";
        private string _email = "john.smith@smithcorp.com";

        public ContactRequestBuilder WithTelephone(string value)
        {
            _telephone = value;
            return this;
        }

        public ContactRequestBuilder WithEmail(string value)
        {
            _email = value;
            return this;
        }

        public ContactRequest Build()
        {
            return new ContactRequest
            {
                TLD = ".com",
                LaunchPhase = "GA",
                Contact = new Contact
                {
                    Name = "John Smith",
                    Organisation = "Smith Corp.",
                    Street1 = "123 Fake Street",
                    Street2 = null,
                    Street3 = null,
                    City = "Somewhere City",
                    State = "Somewhereshire",
                    Postcode = "SW1 2EV",
                    CountryCode = "GB",
                    Telephone = _telephone,
                    TelephoneExtension = null,
                    Email = _email,
                    Fax = null
                }
            };
        }
    }
}
