using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosAreas;
using RRHHCapucasCoffe.Models.EmpleadosBancos;
using RRHHCapucasCoffe.Models.EmpleadosCargos;
using RRHHCapucasCoffe.Models.EmpleadosColegiaciones;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Empleados
{
    public class EmpleadoEditarViewModel : Empleado
    {
        public Familiar Familiar { get; set; }
        public IEnumerable<EmpleadoBancoViewModel> EmpleadoBancos { get; set; }
        public IEnumerable<EmpleadoColegiacionViewModel> EmpleadoColegiaciones { get; set; }
        public IEnumerable<EmpleadoAreaViewModel> EmpleadoAreas { get; set; }
        public IEnumerable<EmpleadoCargoViewModel> EmpleadoCargos { get; set; }
        public string? EmpleadoFotografiaBase64 { get; set; }
        public string EmpleadoFotografiaImg { get; set; }
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

        public IEnumerable<SelectListItem> PaisesNac { get; set; }
        public IEnumerable<SelectListItem> DepartamentoNac { get; set; }
        public IEnumerable<SelectListItem> MunicipioNac { get; set; }
        public IEnumerable<SelectListItem> AldeaNac { get; set; }
        public IEnumerable<SelectListItem> PaisesRes { get; set; }
        public IEnumerable<SelectListItem> DepartamentoRes { get; set; }
        public IEnumerable<SelectListItem> MunicipioRes { get; set; }
        public IEnumerable<SelectListItem> AldeaRes { get; set; }

        public IEnumerable<SelectListItem> EstadosCiviles { get; set; }
        public IEnumerable<SelectListItem> Profesiones { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }
        public IEnumerable<SelectListItem> ColegiosProfesionales { get; set; }
        public IEnumerable<SelectListItem> Agencias { get; set; }
        public IEnumerable<SelectListItem> Cargos { get; set; }
        public IEnumerable<SelectListItem> Modalidades { get; set; }

        public EmpleadoBanco EmpleadoBanco { get; set; }
        public EmpleadoColegiacion EmpleadoColegiacion { get; set; }
        public EmpleadoArea EmpleadoArea { get; set; }
        public EmpleadoCargo EmpleadoCargo { get; set; }
    }
}
