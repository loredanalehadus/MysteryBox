using System.Collections.Generic;

namespace MysteryBox.WebService.Models
{
    public static class Contacts
    {
        public static IEnumerable<Contact> StoredContacts = new List<Contact>
        {
            new Contact
            {
                Name = "Contact 1",
                Email = "contact1@test.com"
            },
            new Contact
            {
                Name = "Contact 2",
                Email = "contact2@test.com"
            },
            new Contact
            {
                Name = "Contact 3",
                Email = "contact3@test.com"
            },
            new Contact
            {
                Name = "Contact 4",
                Email = "contact4@test.com"
            },
            new Contact
            {
                Name = "Contact 5",
                Email = "contact5@test.com"
            }
        };
    }
}
