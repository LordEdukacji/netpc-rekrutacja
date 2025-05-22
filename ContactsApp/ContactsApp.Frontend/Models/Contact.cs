using System.Diagnostics.CodeAnalysis;

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

    public class Categorization
    {
        public long Id { get; set; }
        public required string Category { get; set; }
        public string? Subcategory { get; set; }

        [SetsRequiredMembers]
        public Categorization()
        {
            Category = "";
            Subcategory = "";
        }
    }
}
