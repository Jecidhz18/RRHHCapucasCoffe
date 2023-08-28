using AutoMapper;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Departamento
            CreateMap<Departamento, DeptoEditarViewModel>();
            //Municipio
            CreateMap<Municipio, MunicipioEditarViewModel>();
            CreateMap<PaisDeptoViewModel, MunicipioEditarViewModel>();
        }
    }
}
