using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioRemuneracion
    {
        Task CrearRemuneracion(Remuneracion remuneracion);
        Task EditarRemuneracion(Remuneracion remuneracion);
        Task EliminarRemuneracion(int remuneracionId);
        Task<bool> ExisteRemuneracion(string remuneracionDescripcion);
        Task<IEnumerable<Remuneracion>> ObtenerRemuneracion();
        Task<Remuneracion> ObtenerRemuneracionPorId(int remuneracionId);
    }
}
