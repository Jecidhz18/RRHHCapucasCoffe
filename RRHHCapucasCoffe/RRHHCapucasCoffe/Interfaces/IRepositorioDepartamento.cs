using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDepartamento
    {
        Task CrearDepartamento(DeptoCrearViewModel departamento);
        Task EditarDepartamento(Departamento departamento);
        Task<bool> ExisteDepartamento(string departamentoNombre);
        Task<IEnumerable<Departamento>> ObtenerDepartamento();
        Task<Departamento> ObtenerDepartamentoPorId(int departamentoId);
        Task<IEnumerable<Departamento>> ObtenerDeptoActivoPorPais(Pais pais);
    }
}
