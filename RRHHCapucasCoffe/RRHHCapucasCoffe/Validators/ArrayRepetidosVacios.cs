using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Validators
{
    public class ArrayRepetidosVacios : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int[] arreglo = value as int[];

            // Verificar si hay valores repetidos en el arreglo
            bool tieneValoresRepetidos = arreglo.Length != arreglo.Distinct().Count();

            if (tieneValoresRepetidos)
            {
                // El arreglo tiene valores repetidos, retornar un ValidationResult con el mensaje de error
                return new ValidationResult("Los paises seleccionados no pueden ser los mismos!");
            }

            // La validación es exitosa, retornar ValidationResult.Success
            return ValidationResult.Success;
        }
    }
}
