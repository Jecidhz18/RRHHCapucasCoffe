using RRHHCapucasCoffe.Models.Cargos;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioCargo
    {
        Task CrearCargo(Cargo cargo);
        Task EditarCargo(Cargo cargo);
        Task EliminarCargo(int cargoId);
        Task<bool> ExisteCargo(string cargoNombre);
        Task<IEnumerable<CargoViewModel>> ObtenerCargo();
        Task<Cargo> ObtenerCargoPorId(int cargoId);
    }
}
