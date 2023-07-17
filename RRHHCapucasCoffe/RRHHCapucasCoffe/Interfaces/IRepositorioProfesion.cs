using RRHHCapucasCoffe.Models.Profesiones;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioProfesion
    {
        Task CrearProfesion(Profesion profesion);
        Task EditarProfesion(Profesion profesion);
        Task EliminarProfesion(int profesionId);
        Task<bool> ExisteProfesion(string profesionNombre);
        Task<IEnumerable<Profesion>> ObtenerProfesion();
        Task<Profesion> ObtenerProfesionPorId(int profesionId);
    }
}
