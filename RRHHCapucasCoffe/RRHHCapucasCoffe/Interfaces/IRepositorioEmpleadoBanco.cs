using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleadoBanco
    {
        Task CrearEmpleadoBanco(List<EmpleadoBanco> empleadoBancos, int empleadoId);
    }
}
