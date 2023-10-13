using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoCargo
    {
        Task CrearEmpleadoCargo(List<EmpleadoCargo> empleadoCargos, int empleadoId);
    }
}
