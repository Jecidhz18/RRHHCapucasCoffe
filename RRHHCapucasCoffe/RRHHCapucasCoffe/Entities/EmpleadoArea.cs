namespace RRHHCapucasCoffe.Entities
{
    public class EmpleadoArea
    {
        public int EmpleadoAreaId { get; set; }
        public int EmpleadoId { get; set; }
        public int UnidadId { get; set; }
        public int AgenciaId { get; set; }
        public bool EmpleadoAreaActivo { get; set; }
    }
}
