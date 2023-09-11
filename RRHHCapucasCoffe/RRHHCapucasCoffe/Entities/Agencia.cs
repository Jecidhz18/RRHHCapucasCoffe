using RRHHCapucasCoffe.Models.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Entities
{
    public class Agencia
    {
        public int AgenciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la Agencia")]
        public string AgenciaNombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Activo")]
        public bool AgenciaActiva { get; set; }
        public Guid AgenciaUsuarioGrabo { get; set; }
        public DateTime AgenciaFechaGrabo { get; set; }
    }
}
