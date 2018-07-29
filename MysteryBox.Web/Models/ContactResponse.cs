using Newtonsoft.Json;

namespace MysteryBox.WebService.Models
{
    public class ContactResponse
    {
        public int Id { get; set; }

        public string[] TLDs { get; set; }

        [JsonIgnore]
        public int ResultCode { get; set; }

        [JsonIgnore]
        public string ResultMessage { get; set; }
    }
}
