using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosAreas;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoArea
    {
        Task CrearEmpleadoArea(List<EmpleadoArea> empleadoAreas, int empleadoId);
        Task<IEnumerable<EmpleadoAreaViewModel>> ObtenerEmpleadoAreaPorEmpleadoId(int empleadoId);
    }
}
