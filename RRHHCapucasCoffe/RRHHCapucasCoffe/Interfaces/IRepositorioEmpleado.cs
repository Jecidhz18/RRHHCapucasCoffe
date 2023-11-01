using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Empleados;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleado
    {
        Task<int> CrearEmpleado(Empleado empleado);
        Task EditarEmpleado(Empleado empleado);
        Task<bool> ExisteEmpleado(string empleadoIdentificacion);
        Task<IEnumerable<EmpleadoViewModel>> ObtenerEmpleado();
        Task<Empleado> ObtenerEmpleadoPorId(int empleadoId);
    }
}
