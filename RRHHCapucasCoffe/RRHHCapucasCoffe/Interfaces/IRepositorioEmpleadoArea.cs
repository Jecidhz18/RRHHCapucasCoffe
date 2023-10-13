using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoArea
    {
        Task CrearEmpleadoArea(List<EmpleadoArea> empleadoAreas, int empleadoId);
    }
}
