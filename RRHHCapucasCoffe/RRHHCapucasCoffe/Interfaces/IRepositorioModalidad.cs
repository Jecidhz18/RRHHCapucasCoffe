using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioModalidad
    {
        Task CrearModalidad(Modalidad modalidad);
        Task EditarModalidad(Modalidad modalidad);
        Task<bool> ExisteModalidad(string modalidadNombre);
        Task<IEnumerable<Modalidad>> ObtenerModalidades();
        Task<IEnumerable<Modalidad>> ObtenerModalidadesActivas();
        Task<Modalidad> ObtenerModalidaPorId(int modalidadId);
    }
}
