using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string EmpleadoIdentificacion { get; set; }
        public byte[] EmpleadoFotografia { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombres")]
        public string EmpleadoNombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Primer Apellido")]
        public string EmpleadoPrimerApellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Segundo Apellido")]
        public string EmpleadoSegundoApellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoSexo { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public int EmpleadoDirNacimientoId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime EmpleadoFechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor de EmpleadoEdad debe ser mayor que 0.")]
        public int EmpleadoEdad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EstadoCivilId { get; set; }
        public string EmpleadoTelefono { get; set; }
        public string EmpleadoCelular { get; set; }
        public string EmpleadoDireccion { get; set; }
        public int EmpleadoDireccionId { get; set; }
        public string EmpleadoEmail { get; set; }
        public int FamiliarId { get; set; }
        public int? ProfesionId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyy}", ApplyFormatInEditMode = true)]
        public DateTime EmpleadoFechaIngreso { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EmpleadoFechaContrato { get; set; } 
        public bool EmpleadoActivo { get; set; }
        public Guid EmpleadoUsuarioGrabo { get; set; }
        public DateTime EmpleadoFechaGrabo { get; set; }
        public Guid EmpleadoUsuarioModifico { get; set; }
        public DateTime EmpleadoFechaModifico { get; set; }
    }
}
