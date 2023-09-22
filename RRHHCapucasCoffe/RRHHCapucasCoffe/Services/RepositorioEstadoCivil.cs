using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEstadoCivil : IRepositorioEstadoCivil
    {
        private readonly string connectionString;

        public RepositorioEstadoCivil(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearEstadoCivil(EstadoCivil estadoCivil)
        {
            using var connection = new SqlConnection(connectionString);

            var estadoCivilId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO EstadosCiviles (EstadoCivilNombre, EstadoCivilActivo)
                VALUES (@EstadoCivilNombre, @EstadoCivilActivo)
                SELECT SCOPE_IDENTITY();", estadoCivil);

            estadoCivil.EstadoCivilId = estadoCivilId;
        }

        public async Task<bool> ExisteEstadoCivil(string estadoCivilNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeEstadoCivil = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM EstadosCiviles
                WHERE EstadoCivilNombre = @EstadoCivilNombre;",
                new {estadoCivilNombre});

            return existeEstadoCivil == 1;
        }

        public async Task<IEnumerable<EstadoCivil>> ObtenerEstadoCivil()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EstadoCivil>(
                @"SELECT EstadoCivilId, EstadoCivilNombre, EstadoCivilActivo
                FROM EstadosCiviles");
        }

        public async Task<EstadoCivil> ObtenerEstadoCivilPorId(int estadoCivilId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<EstadoCivil>(
                @"SELECT EstadoCivilId, EstadoCivilNombre, EstadoCivilActivo
                FROM EstadosCiviles
                WHERE EstadoCivilId = @EstadoCivilId", new {estadoCivilId});
        }

        public async Task EditarEstadoCivil(EstadoCivil estadoCivil)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE EstadosCiviles
                SET EstadoCivilNombre = @EstadoCivilNombre, EstadoCivilActivo = @EstadoCivilActivo
                WHERE EstadoCivilId = @EstadoCivilId", estadoCivil);
        }

        public async Task EliminarEstadoCivil(int estadoCivilId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE EstadosCiviles
                WHERE EstadoCivilId = @EstadoCivilId", new {estadoCivilId});
        }

        public async Task<IEnumerable<EstadoCivil>> ObtenerEstadoCivilActivo()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EstadoCivil>(
                @"SELECT EstadoCivilId, EstadoCivilNombre, EstadoCivilActivo
                FROM EstadosCiviles
                WHERE EstadoCivilActivo = '1'");
        }
    }
}
