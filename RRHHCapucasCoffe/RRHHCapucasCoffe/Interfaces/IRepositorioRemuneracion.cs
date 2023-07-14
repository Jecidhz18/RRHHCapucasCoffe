using RRHHCapucasCoffe.Models.Remuneraciones;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioRemuneracion
    {
        Task CrearRemuneracion(Remuneracion remuneracion);
    }
}
