using RRHHCapucasCoffe.Enums;
using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Entities
{
    public class Deduccion
    {
        public int DeduccionId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Deduccion Descripción")]
        public string DeduccionDescripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Activo")]
        public bool DeduccionActiva { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo Aplicación")]
        public int? DeduccionAplicacion { get; set; }
        public int? DeduccionTipoCobro { get; set; }
        public Guid DeduccionUsuarioGrabo { get; set; }
        public DateTime DeduccionFechaGrabo { get; set; }
        public Guid? DeduccionUsuarioModifico { get; set; }
        public DateTime? DeduccionFechaModifico { get; set; }
    }
}
