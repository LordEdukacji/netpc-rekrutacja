namespace ContactsApp.Backend.Models
{
    // limited contact info for contact list
    public class ContactDTO
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public ContactDTO convertToDTO(Contact contact)
        {
            return new ContactDTO() { Id = contact.Id, FirstName = contact.FirstName, LastName = contact.LastName };
        }
    }
}
