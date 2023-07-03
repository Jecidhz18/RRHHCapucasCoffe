using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Validators
{
    public class TodoMayusculaAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) 
            {
                return ValidationResult.Success;
            }

            var x = value.ToString().ToUpper();

            if (value.ToString() == x)
            {
                return new ValidationResult("Todas las letras no pueden ser mayusculas");
            }
            
            return ValidationResult.Success;    
        }

    }
}
