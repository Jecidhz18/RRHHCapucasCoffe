namespace RRHHCapucasCoffe.Entities
{
    public class EmpleadoBanco
    {
        public int EmpleadoBancoId { get; set; }
        public int EmpleadoId { get; set; }
        public int BancoId { get; set; }
        public string EmpleadoBancoNoCuenta { get; set; }
        public bool EmpleadoBancoActiva { get; set; }
    }
}
