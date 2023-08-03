using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Departamentos
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Departamento")]
        [RegularExpression(@"^[A-Z+a-z ]*$", ErrorMessage = "Caracteres no validos")]
        public string DepartamentoNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DepartamentoActivo { get; set; }
    }
}

