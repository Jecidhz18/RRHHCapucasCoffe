namespace RRHHCapucasCoffe.Entities
{
    public class EmpleadoCargo
    {
        public int EmpleadoId { get; set; }
        public int CargoId { get; set; }
        public int ModalidadId { get; set; }
        public DateTime EmpleadoCargoFechaInicio { get; set; }
        public DateTime EmpleadoCargoFechaFinal { get; set; }
        public Decimal EmpleadoCargoSalario { get; set; }
        public string EmpleadoCargoObs { get; set; }
        public bool EmpleadoCargoActivo { get; set; }
    }
}
