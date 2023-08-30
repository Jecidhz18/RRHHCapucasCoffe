using RRHHCapucasCoffe.Models.Aldeas;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioAldea
    {
        Task CrearAldea(AldeaCrearViewModel aldea);
        Task<bool> ExisteAldea(string aldeaNombre);
        Task<IEnumerable<Aldea>> ObtenerAldeas();
    }
}
