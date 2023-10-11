using AutoMapper;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Agencias;
using RRHHCapucasCoffe.Models.Aldeas;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Empleados;
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
            //Empleado
            CreateMap<DireccionEmpleado, EmpleadoCrearViewModel>()
                .ForMember(dest => dest.EmpleadoNacPaisId, opt => opt.MapFrom(src => src.PaisId))
                .ForMember(dest => dest.EmpleadoNacDeptoId, opt => opt.MapFrom(src => src.DepartamentoId))
                .ForMember(dest => dest.EmpleadoNacMpioId, opt => opt.MapFrom(src => src.MunicipioId))
                .ForMember(dest => dest.EmpleadoNacAldeaId, opt => opt.MapFrom(src => src.AldeaId));

        }
    }
}
