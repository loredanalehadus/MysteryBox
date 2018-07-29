using MysteryBox.WebService.Models;

namespace MysteryBox.UnitTests.Mocks
{
    public class ContactRequestBuilder
    {
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
                    Telephone = "+44.1234102010",
                    TelephoneExtension = null,
                    Email = "john.smith@smithcorp.com",
                    Fax = null
                }
            };
        }
    }
}
