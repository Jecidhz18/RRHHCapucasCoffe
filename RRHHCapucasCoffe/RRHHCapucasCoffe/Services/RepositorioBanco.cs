using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Bancos;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioBanco : IRepositorioBanco
    {
        private readonly string connectionString;

        public RepositorioBanco(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearBanco(Banco banco)
        {
            using var connection = new SqlConnection(connectionString);

            var bancoId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Bancos (BancoNombre, BancoActivo, BancoUsuarioGrabo, BancoFechaGrabo)
                VALUES (@BancoNombre, @BancoActivo, @BancoUsuarioGrabo, @BancoFechaGrabo)
                SELECT SCOPE_IDENTITY();", banco);

            banco.BancoId = bancoId;
        }

        public async Task<bool> ExisteBanco(string bancoNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeBanco = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Bancos
                WHERE BancoNombre = @BancoNombre", new {bancoNombre});

            return existeBanco == 1;
        }

        public async Task<IEnumerable<BancoViewModel>> ObtenerBanco()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<BancoViewModel>(
                @"SELECT b.BancoId, b.BancoNombre, b.BancoActivo, 
                         b.BancoUsuarioGrabo, ug.UsuarioCuenta AS BUsuarioGrabo, b.BancoFechaGrabo,
	                     b.BancoUsuarioModifico, um.UsuarioCuenta AS BUsuarioModifico, b.BancoFechaModifico
                FROM Bancos b
                INNER JOIN Usuarios ug ON ug.UsuarioId = b.BancoUsuarioGrabo
                LEFT JOIN Usuarios um ON um.UsuarioId = b.BancoUsuarioModifico;");
        }

        public async Task<Banco> ObtenerBancoPorId(int bancoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Banco>(
                @"SELECT BancoId, BancoNombre, BancoActivo, BancoUsuarioGrabo, BancoFechaGrabo, BancoUsuarioModifico, BancoFechaModifico
                FROM Bancos
                WHERE BancoId = @BancoId", new {bancoId});
        }

        public async Task EditarBanco(Banco banco)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Bancos
                SET BancoNombre = @BancoNombre, BancoActivo = @BancoActivo,
                BancoUsuarioModifico = @BancoUsuarioModifico, BancoFechaModifico = @BancoFechaModifico
                WHERE BancoId = @BancoId", banco);
        }

        public async Task EliminarBanco(int bancoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE Bancos
                WHERE BancoId = @BancoId", new {bancoId});
        }
    }
}
