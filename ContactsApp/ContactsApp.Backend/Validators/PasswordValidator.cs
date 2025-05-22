using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Backend.Validators
{
    // validates passwords
    public class PasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password)) return new ValidationResult("Password: Can't be null");

            // basic password requirements, length, uppercase, number, special symbol

            if (password.Length < 8) return new ValidationResult("Password: Too short, please make it at least 8 characters long");

            if (!password.Any(char.IsUpper)) return new ValidationResult("Password: Must contain an uppercase letter");

            if (!password.Any(char.IsNumber)) return new ValidationResult("Password: Must contain a number");

            if (!password.Any(char.IsPunctuation)) return new ValidationResult("Password: Must contain a punctuation character");

            if (password.Any(char.IsWhiteSpace)) return new ValidationResult("Password: No whitespace");

            return ValidationResult.Success;
        }
    }
}
