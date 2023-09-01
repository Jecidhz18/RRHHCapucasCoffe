namespace RRHHCapucasCoffe.Models.Cargos
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string CargoNombre { get; set; }
        public bool CargoActivo { get; set; }
        public Guid CargoUsuarioGrabo { get; set; }
        public DateTime CargoFechaGrabo { get; set; }
        public string CUsuarioGrabo { get; set; }
    }
}
