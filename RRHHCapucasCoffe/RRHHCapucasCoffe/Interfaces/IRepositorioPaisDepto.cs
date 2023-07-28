using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioPaisDepto
    {
        Task EliminarPaisDepto(DeptoViewModel deptoPais);
        Task EliminarPaisDeptoPorDepto(DeptoViewModel deptoPais);
        Task InsertarPaisDepto(DeptoViewModel deptoPais);
        Task InsertarPaisDeptoPorDepto(DeptoViewModel deptoPais);
    }
}
