using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Pais
    {
        public int DivisionPoliticaPaisId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Pais")]
        public string DivisionPoliticaPaisNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DivisionPoliticaPaisActivo { get; set; }
    }
}
