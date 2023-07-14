using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Usuarios;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly string connectionString;

        public RepositorioUsuario(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> ObtenerUsuario()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<int>(@"SELECT UsuarioId FROM Usuarios WHERE UsuarioId = '2'");
        }
    }
}
