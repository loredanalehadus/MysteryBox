using System.ComponentModel.DataAnnotations;

namespace MysteryBox.WebService.Models
{
    public class Contact
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string Street3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string CountryCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+([0-9]{2})\.([0-9]{10})", ErrorMessage = "Phone number is not in correct format. The pattern is: +<InternationalDialingCode>.<TelephoneNumber>")]
        public string Telephone { get; set; }

        public string TelephoneExtension { get; set; }

        [EmailAddress(ErrorMessage = "Email is not valid. Please enter a correct email format. E.g. name@company.com")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+([0-9]{2})\.([0-9]{10})", ErrorMessage = "Fax number is not in correct format. The pattern is: +<InternationalDialingCode>.<TelephoneNumber>")]
        public string Fax { get; set; }

        public string CustomerId { get; set; }
    }
}