using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Frontend.Validators
{
    // validates phone numbers
    public class PhoneNumberValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = value as string;

            if (string.IsNullOrEmpty(phoneNumber)) return new ValidationResult("Phone number: Can't be null");

            // just numbers
            if (!phoneNumber.All(char.IsNumber)) return new ValidationResult("Phone number: Numbers only");

            return ValidationResult.Success;
        }
    }
}
