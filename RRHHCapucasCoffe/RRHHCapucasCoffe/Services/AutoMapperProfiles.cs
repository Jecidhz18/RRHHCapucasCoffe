using AutoMapper;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Agencias;
using RRHHCapucasCoffe.Models.Aldeas;
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
            //Aldea
            CreateMap<Aldea, AldeaEditarViewModel>();
            CreateMap<PaisDeptoMpioViewModel, AldeaEditarViewModel>();
            //Agencia
            CreateMap<Agencia, AgenciaEditarViewModel>();
            CreateMap<Unidad, AgenciaEditarViewModel>();
        }
    }
}
