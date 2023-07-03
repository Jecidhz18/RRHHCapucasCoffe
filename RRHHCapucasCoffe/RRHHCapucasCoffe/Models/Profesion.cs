namespace RRHHCapucasCoffe.Models
{
    public class Profesion
    {
        public int ProfesionId { get; set; }
        public string ProfesionNombre { get; set; }
        public bool ProfesionActivo { get; set; }
        public int ProfesionUsuarioGrabo { get; set; }
        public DateTime ProfesionFechaGrabo { get; set; }
    }
}
