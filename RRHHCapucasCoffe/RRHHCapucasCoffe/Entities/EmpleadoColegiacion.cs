namespace RRHHCapucasCoffe.Entities
{
    public class EmpleadoColegiacion
    {
        public int EmpleadoColegiacionId { get; set; }
        public int EmpleadoId { get; set; }
        public int ColegioProfesionalId { get; set; }
        public int EmpleadoColegiacionAnio { get; set; }
        public decimal EmpleadoColegiacionCuota { get; set; }
        public bool EmpleadoColegiacionActivo { get; set; }
    }
}