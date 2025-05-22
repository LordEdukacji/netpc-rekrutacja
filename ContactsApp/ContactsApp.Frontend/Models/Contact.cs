namespace ContactsApp.Frontend.Models
{
    public class Contact
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required long CategorizationId { get; set; }
        public required string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }

    public class Categorization
    {
        public long Id { get; set; }
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
    }
}
