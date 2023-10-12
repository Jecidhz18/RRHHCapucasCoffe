using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioFamiliar
    {
        Task<int> CrearFamiliar(Familiar familiar); 
        Task<Familiar> ObtenerFamiliarPorIdentificacion(string familiarIdentificacion;
    }
}
