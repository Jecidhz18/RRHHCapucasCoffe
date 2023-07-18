using RRHHCapucasCoffe.Models.Bancos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioBanco
    {
        Task CrearBanco(Banco banco);
        Task EditarBanco(Banco banco);
        Task EliminarBanco(int bancoId);
        Task<bool> ExisteBanco(string bancoNombre);
        Task<IEnumerable<Banco>> ObtenerBanco();
        Task<Banco> ObtenerBancoPorId(int bancoId);
    }
}
