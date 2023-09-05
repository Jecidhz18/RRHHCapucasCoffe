using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Municipios;
using RRHHCapucasCoffe.Models.TablasUniones;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioMunicipio
    {
        Task CrearMunicipio(Municipio municipio);
        Task EditarMunicipio(MunicipioEditarViewModel municipio);
        Task<bool> ExisteMunicipio(string municipioNombre);
        Task<IEnumerable<Municipio>> ObtenerMunicipio();
        Task<IEnumerable<Municipio>> ObtenerMunicipioActivoPorDepto(PaisDepto paisDepto);
        Task<Municipio> ObtenerMunicipioPorId(int municipioId);
    }
}
