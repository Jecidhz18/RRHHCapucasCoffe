using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Agencias;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioAgencia
    {
        Task CrearAgencia(AgenciaCrearViewModel modelo);
        Task EditarAgencia(AgenciaEditarViewModel agencia);
        Task<bool> ExisteAgencia(string agenciaNombre);
        Task<IEnumerable<AgenciaViewModel>> ObtenerAgencia();
        Task<Agencia> ObtenerAgenciaPorId(int agenciaId);
    }
}
