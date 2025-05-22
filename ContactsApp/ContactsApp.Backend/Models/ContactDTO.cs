using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Backend.Models
{
    // limited contact info for contact list
    public class ContactDTO
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        // create DTO from full contact
        [SetsRequiredMembers]
        public ContactDTO(Contact contact)
        {
            Id = contact.Id;
            FirstName = contact.FirstName;
            LastName = contact.LastName;
        }
    }
}
