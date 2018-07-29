namespace MysteryBox.WebService.Models
{
    public class ContactDetailsResponse : ContactResponse
    {
        public Contact Contact { get; set; }
        public bool Linked { get; set; }
    }
}
