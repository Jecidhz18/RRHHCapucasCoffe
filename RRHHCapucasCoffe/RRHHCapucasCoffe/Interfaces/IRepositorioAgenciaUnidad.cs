using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Agencias;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioAgenciaUnidad
    {
        Task EliminarAgenciaUnidad(int agenciaId);
        Task InsertarAgenciaUnidad(AgenciaCrearViewModel modelo);
        Task InsertarAgenciaUnidadPorAgencia(AgenciaEditarViewModel modelo);
        Task<IEnumerable<Unidad>> ObtenerUnidadPorAgencia(int agenciaId);
    }
}
