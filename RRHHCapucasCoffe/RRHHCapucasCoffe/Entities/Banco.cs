using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Entities
{
    public class Banco
    {
        public int BancoId { get; set; }
        [Required(ErrorMessage = "El campo es requerido!")]
        [NotAllUppercase]
        public string BancoNombre { get; set; }
        public bool BancoActivo { get; set; }
        public Guid BancoUsuarioGrabo { get; set; }
        public DateTime BancoFechaGrabo { get; set; }
        public Guid? BancoUsuarioModifico { get; set; }
        public DateTime? BancoFechaModifico { get; set; }
    }
}
