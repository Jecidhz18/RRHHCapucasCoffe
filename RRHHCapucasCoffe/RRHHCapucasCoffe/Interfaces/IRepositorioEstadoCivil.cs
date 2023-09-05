using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEstadoCivil
    {
        Task CrearEstadoCivil(EstadoCivil estadoCivil);
        Task EditarEstadoCivil(EstadoCivil estadoCivil);
        Task EliminarEstadoCivil(int estadoCivilId);
        Task<bool> ExisteEstadoCivil(string estadoCivil);
        Task<IEnumerable<EstadoCivil>> ObtenerEstadoCivil();
        Task<EstadoCivil> ObtenerEstadoCivilPorId(int estadoCivilId);
    }
}
