using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace MysteryBox.WebService.Models
{
    public class ContactResponse
    {
        public int? Id { get; set; }

        public string[] TLDs { get; set; }

        [JsonIgnore]
        public int ResultCode { get; set; }

        [JsonIgnore]
        public string ResultMessage { get; set; }

        [JsonIgnore]
        public bool HasError => !Regex.IsMatch(ResultCode.ToString(), "^(1)[0-9]{1,3}");
    }
}
