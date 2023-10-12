using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDireccionEmpleado
    {
        Task<int> CrearDireccionEmpleado(DireccionEmpleado direccionEmpleado);
        Task<int> ExisteDireccionEmpleado(DireccionEmpleado direccionEmpleado);
    }
}
