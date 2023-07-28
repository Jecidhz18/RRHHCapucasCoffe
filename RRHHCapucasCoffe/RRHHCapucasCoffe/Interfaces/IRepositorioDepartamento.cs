using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDepartamento
    {
        Task CrearDepartamento(DeptoViewModel departamento);
        Task EditarDepartamento(Departamento departamento);
        Task EliminarDepartamento(int departamentoId);
        Task<bool> ExisteDepartamento(string departamentoNombre);
        Task<IEnumerable<Departamento>> ObtenerDepartamento();
        Task<Departamento> ObtenerDepartamentoPorId(int departamentoId);
    }
}
