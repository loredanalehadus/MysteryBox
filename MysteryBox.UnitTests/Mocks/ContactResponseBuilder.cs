using MysteryBox.WebService.Models;

namespace MysteryBox.UnitTests.Mocks
{
    public class ContactResponseBuilder
    {
        private int resultCode = 100;

        public ContactResponseBuilder WithResultCode(int value)
        {
            resultCode = value;
            return this;
        }

        public ContactResponse Build()
        {
            return new ContactResponse
            {
                ResultCode = resultCode,
                ResultMessage = "Contact Created Successfully",
                Id = 123456,
                TLDs = new[] { ".com" }
            };
        }
    }
}
