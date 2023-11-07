using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosCargos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoCargo
    {
        Task CrearEmpleadoCargo(List<EmpleadoCargo> empleadoCargos, int empleadoId);
        Task EditarEmpleadoCargo(List<EmpleadoCargo> empleadoCargos, int empleadoId);
        Task EliminarEmpleadoCargo(int[] empleadoCargoIds, int empleadoId);
        Task EliminarEmpleadoCargo(int empleadoId);
        Task<IEnumerable<EmpleadoCargoViewModel>> ObtenerEmpleadoCargoPorEmpleadoId(int empleadoId);
    }
}
