using ContactsApp.Frontend.Validators;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactsApp.Frontend.Models
{
    // send to API endpoints when creating and editing contacts
    public class ContactWithCategorization
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [PasswordValidator]
        public required string Password { get; set; }
        public required Categorization Categories { get; set; }
        [PhoneNumberValidator]
        public required string PhoneNumber { get; set; }
        public required DateOnly DateOfBirth { get; set; }

        // empty initialization for forms
        [SetsRequiredMembers]
        public ContactWithCategorization()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Password = "";
            Categories = new Categorization();
            PhoneNumber = "";
            DateOfBirth = default;
        }

        // Categorization has to be fetched and set separately
        [SetsRequiredMembers]
        public ContactWithCategorization(Contact contact)
        {
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            Email = contact.Email;
            Password = contact.Password;
            Categories = new Categorization();
            PhoneNumber = contact.PhoneNumber;
            DateOfBirth = contact.DateOfBirth;
        }
    }
}
