using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Deducciones
{
    public class DeduccionEditarViewModel : Deduccion
    {
        public IEnumerable<DeduccionCobro> DeduccionesCobros { get; set; }
        public List<DeduccionCobro> DeduccionCobros { get; set; }
    }
}
