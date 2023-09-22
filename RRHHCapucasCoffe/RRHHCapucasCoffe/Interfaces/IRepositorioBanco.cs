using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Bancos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioBanco
    {
        Task CrearBanco(Banco banco);
        Task EditarBanco(Banco banco);
        Task EliminarBanco(int bancoId);
        Task<bool> ExisteBanco(string bancoNombre);
        Task<IEnumerable<BancoViewModel>> ObtenerBanco();
        Task<Banco> ObtenerBancoPorId(int bancoId);
        Task<IEnumerable<Banco>> ObtenerBancosActivos();
    }
}
