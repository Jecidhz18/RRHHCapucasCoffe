using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Departamento
    {
        public int DivisionPoliticaDepartamentoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Departamento")]
        public string DivisionPoliticaDepartamentoNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DivisionPoliticaDepartamentoActivo { get; set; }
    }
}
