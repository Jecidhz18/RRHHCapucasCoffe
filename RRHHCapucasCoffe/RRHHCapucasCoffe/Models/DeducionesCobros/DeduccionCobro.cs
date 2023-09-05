namespace RRHHCapucasCoffe.Models.DeducionesCobros
{
    public class DeduccionCobro
    {
        public int DeduccionCobroId { get; set; }
        public int DeduccionId { get; set; }
        public decimal DeduccionCobroDesde { get; set; }
        public decimal DeduccionCobroHasta { get; set; }
        public decimal DeduccionCobroPorcentaje { get; set; }
        public decimal DeduccionCobroMonto { get; set; }
    }
}
