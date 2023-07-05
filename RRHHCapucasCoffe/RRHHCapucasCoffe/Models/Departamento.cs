using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Departamento")]
        public string DepartamentoNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DepartamentoActivo { get; set; }
    }
}
