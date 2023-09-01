namespace RRHHCapucasCoffe.Models.Deducciones
{
    public class Deduccion
    {
        public int DeduccionId { get; set; }
        public string DeduccioneDescripcion { get; set; }
        public bool DeduccionActiva { get; set; }
        public int DeduccionAplicacion { get; set; }
        public int DeduccionTipoCobro { get; set; }
        public Guid DeduccionUsuarioGrabo { get; set; }
        public DateTime DeduccionFechaGrabo { get; set; }
        public Guid DeduccionUsuarioModifico { get; set; }
        public DateTime DeduccionFechaModifico { get; set; }
    }
}
