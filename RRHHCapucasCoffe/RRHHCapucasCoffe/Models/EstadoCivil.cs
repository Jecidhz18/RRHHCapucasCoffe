using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class EstadoCivil
    {
        public int EstadoCivilId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado Civil")]
        [PrimeraLetraMayusAtribute]
        [TodoMayusculaAtribute]
        [RegularExpression(@"^[A-Z+a-z ]*$", ErrorMessage = "Caracteres no validos")]
        public string EstadoCivilNombre { get; set; }
        [Display(Name = "Activo")]
        public bool EstadoCivilActivo { get; set; }
    }
}
