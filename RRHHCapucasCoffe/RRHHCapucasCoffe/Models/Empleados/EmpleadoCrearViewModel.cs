using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Empleados
{
    public class EmpleadoCrearViewModel : Empleado
    {
        public string? EmpleadoFotografiaBase64 { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoNacPaisId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoNacDeptoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoNacMpioId { get; set; }
        public int? EmpleadoNacAldeaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoDirPaisId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoDirDeptoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? EmpleadoDirMpioId { get; set; }
        public int? EmpleadoDirAldeaId { get; set; }
        [Required]
        public Familiar Familiar { get; set; }
        public EmpleadoBanco EmpleadoBanco { get; set; }
        public EmpleadoColegiacion EmpleadoColegiacion {get; set;}
        public EmpleadoArea EmpleadoArea { get; set; }
        public EmpleadoCargo EmpleadoCargo { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> EstadosCiviles { get; set; }
        public IEnumerable<SelectListItem> Profesiones { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }
        public IEnumerable<SelectListItem> ColegiosProfesionales { get; set; }
        public IEnumerable<SelectListItem> Agencias { get; set; }
        public IEnumerable<SelectListItem> Cargos { get; set; }
        public IEnumerable<SelectListItem> Modalidades { get; set; }
        public List<EmpleadoBanco> EmpleadoBancos { get; set; }
        public List<EmpleadoColegiacion> EmpleadoColegiaciones { get; set; }
        public List<EmpleadoArea> EmpleadoAreas { get; set; }
        public List<EmpleadoCargo> EmpleadoCargos { get; set; }
    }
}
