using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Frontend.Models
{
    // full contact, needs to fetch categories separately
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

        // empty initialization for form models
        [SetsRequiredMembers]
        public Contact()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Password = "";
            CategorizationId = 0;
            PhoneNumber = "";
            DateOfBirth = new();
        }

        // copy fields from contact with categorization object
        [SetsRequiredMembers]
        public Contact(ContactWithCategorization contactWithCategorization)
        {
            FirstName = contactWithCategorization.FirstName;
            LastName = contactWithCategorization.LastName;
            Email = contactWithCategorization.Email;
            Password = contactWithCategorization.Password;
            PhoneNumber = contactWithCategorization.PhoneNumber;
            DateOfBirth = contactWithCategorization.DateOfBirth;

            CategorizationId = contactWithCategorization.Categories.Id;
        }
    }

    // categories, held and fetched separately
    public class Categorization
    {
        public long Id { get; set; }
        public required string Category { get; set; }
        public string? Subcategory { get; set; }

        [SetsRequiredMembers]
        public Categorization()
        {
            // if not set differently later
            Category = "Other";
            Subcategory = "Unknown";
        }
    }
}
