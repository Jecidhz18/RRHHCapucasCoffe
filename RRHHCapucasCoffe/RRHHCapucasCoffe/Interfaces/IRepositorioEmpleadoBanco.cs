using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.EmpleadosBancos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoBanco
    {
        Task CrearEmpleadoBanco(List<EmpleadoBanco> empleadoBancos, int empleadoId);
        Task EditarEmpleadoBanco(List<EmpleadoBanco> empleadoBancos, int empleadoId);
        Task EliminarEmpleadoBanco(int[] empleadoBancoIds, int empleadoId);
        Task<IEnumerable<EmpleadoBancoViewModel>> ObtenerEmpleadoBancoPorEmpleadoId(int empleadoId);
    }
}
