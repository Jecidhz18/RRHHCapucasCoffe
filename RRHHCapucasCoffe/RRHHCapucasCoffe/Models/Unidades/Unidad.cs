using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Unidades
{
    public class Unidad
    {
        public int UnidadId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la Unidad")]
        [PrimeraLetraMayusAtribute]
        [TodoMayusculaAtribute]
        [RegularExpression(@"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no validos")]
        public string UnidadDescripcion { get; set; }
        [Display(Name = "Activo")]
        public bool UnidadActiva { get; set; }
        [Display(Name = "Usuario Grabo")]
        public int UnidadUsuarioGrabo { get; set; } 
        [Display(Name = "Fecha Grabo")]
        public DateTime UnidadFechaGrabo { get; set; }
        [Display(Name = "Usuario Actualizo")]
        public int UnidadUsuarioModifico { get; set; }
        [Display(Name = "Fecha Actualizo")]
        public DateTime UnidadFechaModifico { get; set; }
        public string UsuarioGrabo { get; set; }
        public string UsuarioModifico { get; set; }
    }
}
