using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Aldea
    {
        public int DivisionPoliticaAldeaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la Aldea")]
        public string DivisionPoliticaAldeaNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DivisionPoliticaAldeaActivo { get; set; }
    }
}
