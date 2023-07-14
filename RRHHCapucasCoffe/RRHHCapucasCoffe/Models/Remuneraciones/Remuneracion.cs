using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Remuneraciones
{
    public class Remuneracion
    {
        public int RemuneracionId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Descripción")]
        [PrimeraLetraMayusAtribute]
        [TodoMayusculaAtribute]
        [RegularExpression(@"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no validos")]
        public string RemuneracionDescripcion { get; set; }
        [Display(Name = "Activo")]
        public bool RemuneracionActiva { get; set; }
    }
}
