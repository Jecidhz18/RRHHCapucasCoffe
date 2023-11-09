using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Deducciones
{
    public class DeduccionViewModel : Deduccion
    {
        public string DAplicacion { get; set; }
        public string DTipoCobro { get; set; }
        public string DUsuarioGrabo { get; set; }
        public string DUsuarioModifico { get; set; }
    }
}
