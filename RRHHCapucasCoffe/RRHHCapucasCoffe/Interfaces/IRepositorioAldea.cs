using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Aldeas;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioAldea
    {
        Task CrearAldea(AldeaCrearViewModel aldea);
        Task EditarAldea(AldeaEditarViewModel aldea);
        Task<bool> ExisteAldea(string aldeaNombre);
        Task<Aldea> ObtenerAldeaPorId(int aldeaId);
        Task<IEnumerable<Aldea>> ObtenerAldeas();
    }
}
