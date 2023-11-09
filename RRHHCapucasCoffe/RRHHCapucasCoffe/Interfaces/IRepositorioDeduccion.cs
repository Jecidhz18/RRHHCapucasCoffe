using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Deducciones;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDeduccion
    {
        Task<int> CrearDeduccion(Deduccion deduccion);
        Task EditarDeduccion(Deduccion deduccion);
        Task<IEnumerable<DeduccionViewModel>> ObtenerDeduccion();
        Task<Deduccion> ObtenerDeduccionPorId(int deduccionId);
    }
}
