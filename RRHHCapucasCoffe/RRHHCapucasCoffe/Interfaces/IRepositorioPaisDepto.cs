using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioPaisDepto
    {
        Task EliminarPaisDeptoPorDepto(DeptoEditarViewModel deptoPais);
        Task InsertarPaisDepto(DeptoCrearViewModel deptoPais);
        Task InsertarPaisDeptoPorDepto(DeptoEditarViewModel deptoPais);
    }
}
