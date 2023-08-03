using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.ColegiosProfesionales
{
    public class ColegioProfesional
    {
        public int ColegioProfesionalId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Colegio Profesional")]
        [PrimeraLetraMayusAtribute]
        [NotAllUppercase]
        [RegularExpression(@"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no validos")]
        public string ColegioProfesionalNombre { get; set; }
        [Display(Name = "Activo")]
        public bool ColegioProfesionalActivo { get; set; }
    }
}
