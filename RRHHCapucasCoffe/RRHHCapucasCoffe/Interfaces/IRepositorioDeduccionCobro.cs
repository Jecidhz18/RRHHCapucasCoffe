using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioDeduccionCobro
    {
        Task CrearDeduccionCobro(List<DeduccionCobro> deduccionCobros, int deduccionId);
    }
}
