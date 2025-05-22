using ContactsApp.Backend.Validators;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Backend.Models
{
    // contains a categorization object directly
    // used in POST and PUT requests,
    // so that the client does not have to make additional calls to create the categorization entity
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
        public DateOnly DateOfBirth { get; set; }
    }
}
