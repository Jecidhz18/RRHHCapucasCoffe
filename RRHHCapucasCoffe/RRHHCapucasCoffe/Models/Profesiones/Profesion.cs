namespace RRHHCapucasCoffe.Models.Profesiones
{
    public class Profesion
    {
        public int ProfesionId { get; set; }
        public string ProfesionNombre { get; set; }
        public bool ProfesionActivo { get; set; }
        public Guid ProfesionUsuarioGrabo { get; set; }
        public DateTime ProfesionFechaGrabo { get; set; }
    }
}
