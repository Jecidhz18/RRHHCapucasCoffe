using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioMunicipio
    {
        Task CrearMunicipio(Municipio municipio);
        Task<bool> ExisteMunicipio(string municipioNombre);
        Task<Municipio> ObtenerMunicipioPorId(int municipioId);
    }
}
