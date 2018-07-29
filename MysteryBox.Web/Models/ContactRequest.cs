namespace MysteryBox.WebService.Models
{
    public class ContactRequest
    {
        public string TLD { get; set; }
        public string LaunchPhase { get; set; }
        public Contact Contact { get; set; }
    }
}
