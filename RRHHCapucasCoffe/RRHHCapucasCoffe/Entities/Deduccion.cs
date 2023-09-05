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
        [NotAllUppercase]
        [PrimeraLetraMayusAtribute]
        public string DeduccioneDescripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Activo")]
        public bool DeduccionActiva { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo Aplicación")]
        public DeduccionAplicaciones DeduccionAplicacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo Cobro")]
        public DeduccionTiposCobros DeduccionTipoCobro { get; set; }
        public Guid DeduccionUsuarioGrabo { get; set; }
        public DateTime DeduccionFechaGrabo { get; set; }
        public Guid? DeduccionUsuarioModifico { get; set; }
        public DateTime? DeduccionFechaModifico { get; set; }
    }
}
