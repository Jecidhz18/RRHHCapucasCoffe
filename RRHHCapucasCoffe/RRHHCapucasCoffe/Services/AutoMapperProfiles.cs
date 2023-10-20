using AutoMapper;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Agencias;
using RRHHCapucasCoffe.Models.Aldeas;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.DireccionesEmpleados;
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
            CreateMap<EmpleadoCrearViewModel, DireccionEmpleadoNacimiento>()
                .ForMember(dest => dest.PaisId, opt => opt.MapFrom(src => src.EmpleadoNacPaisId))
                .ForMember(dest => dest.DepartamentoId, opt => opt.MapFrom(src => src.EmpleadoNacDeptoId))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.EmpleadoNacMpioId))
                .ForMember(dest => dest.AldeaId, opt => opt.MapFrom(src => src.EmpleadoNacAldeaId)).ReverseMap();
            CreateMap<EmpleadoCrearViewModel, DireccionEmpleadoResidencia>()
                .ForMember(dest => dest.PaisId, opt => opt.MapFrom(src => src.EmpleadoDirPaisId))
                .ForMember(dest => dest.DepartamentoId, opt => opt.MapFrom(src => src.EmpleadoDirDeptoId))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.EmpleadoDirMpioId))
                .ForMember(dest => dest.AldeaId, opt => opt.MapFrom(src => src.EmpleadoDirAldeaId)).ReverseMap();
            CreateMap<EmpleadoCrearViewModel, Empleado>().ReverseMap();

            CreateMap<EmpleadoEditarViewModel, Empleado>().ReverseMap();

            CreateMap<DireccionEmpleadoNacimiento, EmpleadoEditarViewModel>()
                .ForMember(dest => dest.EmpleadoNacPaisId, opt => opt.MapFrom(src => src.PaisId))
                .ForMember(dest => dest.EmpleadoNacDeptoId, opt => opt.MapFrom(src => src.DepartamentoId))
                .ForMember(dest => dest.EmpleadoNacMpioId, opt => opt.MapFrom(src => src.MunicipioId))
                .ForMember(dest => dest.EmpleadoNacAldeaId, opt => opt.MapFrom(src => src.AldeaId)).ReverseMap();
            CreateMap<DireccionEmpleadoResidencia, EmpleadoEditarViewModel>()
                .ForMember(dest => dest.EmpleadoDirPaisId, opt => opt.MapFrom(src => src.PaisId))
                .ForMember(dest => dest.EmpleadoDirDeptoId, opt => opt.MapFrom(src => src.DepartamentoId))
                .ForMember(dest => dest.EmpleadoDirMpioId, opt => opt.MapFrom(src => src.MunicipioId))
                .ForMember(dest => dest.EmpleadoDirAldeaId, opt => opt.MapFrom(src => src.AldeaId)).ReverseMap();
        }
    }
}
