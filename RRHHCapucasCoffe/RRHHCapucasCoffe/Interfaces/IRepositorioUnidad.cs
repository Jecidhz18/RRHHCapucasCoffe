using RRHHCapucasCoffe.Models.Unidades;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioUnidad
    {
        Task CrearUnidad(Unidad unidad);
        Task EditarUnidad(Unidad unidad);
        Task EliminarUnidad(int unidadId);
        Task<bool> ExisteUnidad(string unidadNombre);
        Task<IEnumerable<UnidadViewModel>> ObtenerUnidad();
        Task<Unidad> ObtenerUnidadPorId(int unidadId);
    }
}
