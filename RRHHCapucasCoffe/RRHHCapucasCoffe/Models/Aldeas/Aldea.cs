using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Aldeas
{
    public class Aldea
    {
        public int AldeaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la Aldea")]
        public string AldeaNombre { get; set; }
        [Display(Name = "Activo")]
        public bool AldeaActivo { get; set; }
    }
}
