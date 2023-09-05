using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioColegioProfesional : IRepositorioColegioProfesional
    {
        private readonly string connectionString;
        public RepositorioColegioProfesional(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public async Task CrearColegioProfesional(ColegioProfesional colegioProfesional)
        {
            using var connection = new SqlConnection(connectionString);

            var colegioProfesionalId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO ColegiosProfesionales (ColegioProfesionalNombre, ColegioProfesionalActivo)
                VALUES (@ColegioProfesionalNombre, @ColegioProfesionalActivo) 
                SELECT SCOPE_IDENTITY();", colegioProfesional);

            colegioProfesional.ColegioProfesionalId = colegioProfesionalId;
        }

        public async Task<bool> ExisteColegioProfesional(string colegioProfesionalNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var exiteColegioProfesional = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM ColegiosProfesionales 
                WHERE ColegioProfesionalNombre = @ColegioProfesionalNombre;",
                new {colegioProfesionalNombre});

            return exiteColegioProfesional == 1;
        }

        public async Task<IEnumerable<ColegioProfesional>> ObtenerColegioProfesional()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<ColegioProfesional>(
                @"SELECT ColegioProfesionalId, ColegioProfesionalNombre, ColegioProfesionalActivo 
                FROM ColegiosProfesionales");
        }

        public async Task<ColegioProfesional> ObtenerColegioProfesionalPorId(int colegioProfesionalId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<ColegioProfesional>(
                @"SELECT ColegioProfesionalId, ColegioProfesionalNombre, ColegioProfesionalActivo
                FROM ColegiosProfesionales
                WHERE ColegioProfesionalId = @ColegioProfesionalId", new {colegioProfesionalId}
                );
        }

        public async Task EditarColegioProfesional(ColegioProfesional colegioProfesional)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE ColegiosProfesionales
                SET ColegioProfesionalNombre = @ColegioProfesionalNombre, ColegioProfesionalActivo = @ColegioProfesionalActivo
                WHERE ColegioProfesionalId = @ColegioProfesionalId", colegioProfesional);
        }

        public async Task EliminarColegioProfesional(int colegioProfesionalId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE ColegiosProfesionales
                WHERE ColegioProfesionalId = @ColegioProfesionalId",new { colegioProfesionalId });
        }
    }
}
