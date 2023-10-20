using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosCargos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoCargo
    {
        Task CrearEmpleadoCargo(List<EmpleadoCargo> empleadoCargos, int empleadoId);
        Task<IEnumerable<EmpleadoCargoViewModel>> ObtenerEmpleadoCargoPorEmpleadoId(int empleadoId);
    }
}
