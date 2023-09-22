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

        public async Task<Usuario> ObtenerUsuario()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Usuario>(
                @"SELECT UsuarioId, UsuarioCuenta 
                FROM Usuarios 
                WHERE UsuarioId = 'ABB27757-6CAD-4EED-88C3-11CBACCAFCF9'");

            //return await connection.QueryFirstOrDefaultAsync<Usuario>(
            //    @"SELECT UsuarioId, UsuarioCuenta 
            //    FROM Usuarios 
            //    WHERE UsuarioId = '033043d2-769c-42a4-9886-7ca009968372'");
        }
    }
}
