using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDepartamento
    {
        Task CrearDepartamento(Departamento departamento);
        //Task CrearReferencia(IEnumerable<PaisDepto> paises, int departamentoId);
        Task<IEnumerable<Departamento>> ObtenerDepartamento();
        //Task<int> ObtenerUltimoDepartamentoId();
    }
}
