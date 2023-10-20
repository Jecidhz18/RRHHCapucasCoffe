using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosColegiaciones;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoColegiacion
    {
        Task CrearEmpleadoColegiacion(List<EmpleadoColegiacion> empleadoColegiaciones, int empleadoId);
        Task<IEnumerable<EmpleadoColegiacionViewModel>> ObtenerEmpleadoColegiacionPorEmpleadoId(int empleadoId);
    }
}
