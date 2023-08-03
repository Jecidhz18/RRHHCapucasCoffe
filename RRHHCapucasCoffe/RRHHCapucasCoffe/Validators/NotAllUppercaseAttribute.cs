using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Validators
{
    public class NotAllUppercaseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check if the value contains only uppercase letters.
            if (value is string str && str.All(char.IsUpper))
            {
                // The value contains only uppercase letters.
                return new ValidationResult("No todas las letras pueden ser mayusculas.");
            }
            else
            {
                // The value does not contain only uppercase letters.
                return ValidationResult.Success;
            }
        }
    }
}
