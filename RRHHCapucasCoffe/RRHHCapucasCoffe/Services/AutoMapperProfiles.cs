using AutoMapper;
using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Departamento, DeptoEditarViewModel>();
        }
    }
}
