namespace MysteryBox.WebService.Models
{
    public class ContactRequest
    {
        public string TLD { get; set; }
        public string LaunchPhase { get; set; }
        public string Name { get; set; }
        public string Organisation { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
        public string Telephone { get; set; }
        public string TelephoneExtension { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}
