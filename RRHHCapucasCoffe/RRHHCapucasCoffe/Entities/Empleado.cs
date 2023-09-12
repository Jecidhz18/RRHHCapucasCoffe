using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string EmpleadoIdentificacion { get; set; }
        public byte[] EmpleadoFotografia { get; set; }
        [Display(Name = "Nombres")]
        public string EmpleadoNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string EmpleadoPrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string EmpleadoSegundoApellido { get; set; }
        public int EmpleadoSexo { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public int EmpleadoDirNacimientoId { get; set; }
        public DateTime EmpleadoFechaNacimiento { get; set; }
        public int EmpleadoEdad { get; set; }
        public int EstadoCivilId { get; set; }
        public string EmpleadoTelefono { get; set; }
        public string EmpleadoCelular { get; set; }
        public string EmpleadoDireccion { get; set; }
        public int EmpleadoDireccionId { get; set; }
        public string EmpleadoEmail { get; set; }
        public int FamiliarId { get; set; }
        public int ProfesionId { get; set; }
        public DateTime EmpleadoFechaIngreso { get; set; }
        public DateTime EmpleadoFechaContrato { get; set; }
        public bool EmpleadoActivo { get; set; }
        public Guid EmpleadoUsuarioGrabo { get; set; }
        public DateTime EmpleadoFechaGrabo { get; set; }
        public Guid EmpleadoUsuarioModifico { get; set; }
        public DateTime EmpleadoFechaModifico { get; set; }
    }
}
