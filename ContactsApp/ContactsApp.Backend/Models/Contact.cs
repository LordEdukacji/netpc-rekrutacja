using ContactsApp.Backend.Validators;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Backend.Models
{
    // used for storage
    // categories are represented with a reference to another table in DB
    public class Contact
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [PasswordValidator]
        public required string Password { get; set; }
        public required long CategorizationId { get; set; }
        [PhoneNumberValidator]
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

    // separate table for categories
    public class Categorization {
        public long Id { get; set; }
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
    }

}
