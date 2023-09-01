using RRHHCapucasCoffe.Models.Usuarios;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioUsuario
    {
        Task<Usuario> ObtenerUsuario();
    }
}
