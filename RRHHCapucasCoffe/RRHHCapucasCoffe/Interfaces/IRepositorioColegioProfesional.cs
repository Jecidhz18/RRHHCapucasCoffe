using RRHHCapucasCoffe.Models.ColegiosProfesionales;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioColegioProfesional
    {
        Task CrearColegioProfesional(ColegioProfesional colegioProfesional);
        Task EditarColegioProfesional(ColegioProfesional colegioProfesional);
        Task EliminarColegioProfesional(int colegioProfesionalId);
        Task<bool> ExisteColegioProfesional(string colegioProfesionalNombre);
        Task<IEnumerable<ColegioProfesional>> ObtenerColegioProfesional();
        Task<ColegioProfesional> ObtenerColegioProfesionalPorId(int colegioProfesionalId);
    }
}
