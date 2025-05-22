using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Backend.Models
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

        // the CategorizationId has to be set in contactWithCategorization before that
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

        public Contact()
        {
        }
    }

    public class Categorization {
        public long Id { get; set; }
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
    }

}
