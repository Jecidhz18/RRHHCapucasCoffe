using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDeptoMunicipio
    {
        Task InsertarDeptoMunicipio(MunicipioCrearViewModel deptoMunicipio);
    }
}
