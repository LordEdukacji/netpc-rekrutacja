namespace ContactsApp.Frontend.Models
{
    // for contact list
    public class ContactDTO
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
