using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleado
    {
        Task<int> CrearEmpleado(Empleado empleado);
        Task<bool> ExisteEmpleado(string empleadoIdentificacion);
    }
}
