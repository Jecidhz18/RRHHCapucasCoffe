using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Empleados
{
    public class EmpleadoCrearViewModel : Empleado
    {
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
    }
}
