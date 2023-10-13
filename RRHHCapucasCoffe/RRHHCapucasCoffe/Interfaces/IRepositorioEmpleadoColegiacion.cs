using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoColegiacion
    {
        Task CrearEmpleadoColegiacion(List<EmpleadoColegiacion> empleadoColegiaciones, int empleadoId);
    }
}
