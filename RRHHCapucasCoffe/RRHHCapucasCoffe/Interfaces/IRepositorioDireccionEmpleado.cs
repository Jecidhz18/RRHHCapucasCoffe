using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.DireccionesEmpleados;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDireccionEmpleado
    {
        Task<int> CrearDireccionEmpleado(DireccionEmpleado direccionEmpleado);
        Task<int> ExisteDireccionEmpleado(DireccionEmpleado direccionEmpleado);
        Task<DireccionEmpleadoNacimiento> ObtenerDireccionEmpleadoNacPorId(int direccionEmpleadoId);
        Task<DireccionEmpleadoResidencia> ObtenerDireccionEmpleadoResPorId(int direccionEmpleadoId);
    }
}
