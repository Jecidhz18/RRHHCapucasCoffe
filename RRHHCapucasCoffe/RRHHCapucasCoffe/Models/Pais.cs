using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Pais
    {
        public int PaisId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Pais")]
        [PrimeraLetraMayusAtribute]
        [TodoMayusculaAtribute]
        [RegularExpression(@"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no validos")]
        public string PaisNombre { get; set; }
        [Display(Name = "Activo")]
        public bool PaisActivo { get; set; }
    }
}
