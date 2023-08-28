using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioMunicipio
    {
        Task CrearMunicipio(Municipio municipio);
        Task EditarMunicipio(MunicipioEditarViewModel municipio);
        Task<bool> ExisteMunicipio(string municipioNombre);
        Task<IEnumerable<Municipio>> ObtenerMunicipio();
        Task<Municipio> ObtenerMunicipioPorId(int municipioId);
    }
}
