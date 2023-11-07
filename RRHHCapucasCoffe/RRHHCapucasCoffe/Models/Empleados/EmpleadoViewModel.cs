using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.EmpleadosAreas;
using RRHHCapucasCoffe.Models.EmpleadosBancos;
using RRHHCapucasCoffe.Models.EmpleadosCargos;
using RRHHCapucasCoffe.Models.EmpleadosColegiaciones;

namespace RRHHCapucasCoffe.Models.Empleados
{
    public class EmpleadoViewModel : Empleado
    {
        public Familiar Familiar { get; set; }
        public IEnumerable<EmpleadoBancoViewModel> EmpleadoBancos { get; set; }
        public IEnumerable<EmpleadoColegiacionViewModel> EmpleadoColegiaciones { get; set; }
        public IEnumerable<EmpleadoAreaViewModel> EmpleadoAreas { get; set; }
        public IEnumerable<EmpleadoCargoViewModel> EmpleadoCargos { get; set; }
        public string PaisRes { get; set; }
        public string DepartamentoRes { get; set; }
        public string MunicipioRes { get; set; }
        public string AldeaRes { get; set; }
        public string EstadoCivilNombre { get; set; }
        public string ProfesionNombre { get; set; }
        public string CargoNombre { get; set; }

    }
}
