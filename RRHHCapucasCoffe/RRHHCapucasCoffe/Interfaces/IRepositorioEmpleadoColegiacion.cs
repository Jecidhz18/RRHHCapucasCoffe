using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosColegiaciones;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoColegiacion
    {
        Task CrearEmpleadoColegiacion(List<EmpleadoColegiacion> empleadoColegiaciones, int empleadoId);
        Task EditarEmpleadoColegiacion(List<EmpleadoColegiacion> empleadoColegiaciones, int empleadoId);
        Task EliminarEmpleadoColegiacion(int[] empleadoColegiacionIds, int empleadoId);
        Task EliminarEmpleadoColegiacion(int empleadoId);
        Task<IEnumerable<EmpleadoColegiacionViewModel>> ObtenerEmpleadoColegiacionPorEmpleadoId(int empleadoId);
    }
}
