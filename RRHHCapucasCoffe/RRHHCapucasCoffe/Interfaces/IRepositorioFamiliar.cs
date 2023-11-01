using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioFamiliar
    {
        Task<int> CrearFamiliar(Familiar familiar);
        Task EditarFamiliar(Familiar familiar);
        Task<Familiar> ObtenerFamiliarPorId(int familiarId);
        Task<Familiar> ObtenerFamiliarPorIdentificacion(string familiarIdentificacion);
    }
}
