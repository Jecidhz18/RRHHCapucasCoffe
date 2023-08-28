using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDeptoMunicipio
    {
        Task EliminarDeptoMpioPorMpio(MunicipioEditarViewModel modelo);
        Task InsertarDeptoMunicipio(MunicipioCrearViewModel deptoMunicipio);
        Task InsertarDeptoMunicipioEditar(MunicipioEditarViewModel modelo);
        Task<IEnumerable<PaisDeptoViewModel>> ObtenerPaisDeptoPorMpio(int municipioId);
    }
}
