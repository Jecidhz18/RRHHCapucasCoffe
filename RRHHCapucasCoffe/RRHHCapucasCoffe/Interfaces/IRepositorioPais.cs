using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioPais
    {
        Task ActualizarPais(Pais pais);
        Task CrearPais(Pais pais);
        Task EliminarPais(int paisId);
        Task<bool> ExistePais(string paisNombre);
        Task<IEnumerable<Pais>> ObtenerPais();
        Task<IEnumerable<Pais>> ObtenerPaisActivo();
        Task<IEnumerable<Pais>> ObtenerPaisPorDepto(int departamentoId);
        Task<Pais> ObtenerPaisPorId(int paisId);
    }
}
