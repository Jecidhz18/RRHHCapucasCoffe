using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDeduccionCobro
    {
        Task CrearDeduccionCobro(List<DeduccionCobro> deduccionCobros, int deduccionId);
        Task EditarDeduccionCobro(List<DeduccionCobro> deduccionCobros, int deduccionId);
        Task EliminarDeduccionCobro(int[] deduccionCobroIds, int deduccionId);
        Task EliminarDeduccionCobro(int deduccionId);
        Task<IEnumerable<DeduccionCobro>> ObtenerDeduccionCobrosPorDeduccionId(int deduccionId);
    }
}
