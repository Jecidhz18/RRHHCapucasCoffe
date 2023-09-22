using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Empleados
{
    public class EmpleadoCrearViewModel : Empleado
    {
        public Familiar Familiar { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> EstadosCiviles { get; set; }
        public IEnumerable<SelectListItem> Profesiones { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }
    }
}
