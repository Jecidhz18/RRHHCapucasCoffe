using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Remuneraciones;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioRemuneracion : IRepositorioRemuneracion
    {
        private readonly string connectionString;

        public RepositorioRemuneracion(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CrearRemuneracion(Remuneracion remuneracion)
        {
            using var connection = new SqlConnection(connectionString);

            var remuneracionId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Remuneraciones (RemuneracionDescripcion, RemuneracionActiva)
                VALUES (@RemuneracionDescripcion, @RemuneracionActiva)
                SELECT SCOPE_IDENTITY();", remuneracion);

            remuneracion.RemuneracionId = remuneracionId;
        }

        public async Task<bool> ExisteRemuneracion(string remuneracionDescripcion)
        {
            using var connection = new SqlConnection(connectionString);

            var existeRemuneracion = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Remuneraciones
                WHERE RemuneracionDescripcion = @RemuneracionDescripcion", new {remuneracionDescripcion});

            return existeRemuneracion == 1;
        }

        public async Task<IEnumerable<Remuneracion>> ObtenerRemuneracion()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Remuneracion>(
                @"SELECT RemuneracionId, RemuneracionDescripcion, RemuneracionActiva
                FROM Remuneraciones");
        }

        public async Task<Remuneracion> ObtenerRemuneracionPorId(int remuneracionId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Remuneracion>(
                @"SELECT RemuneracionId, RemuneracionDescripcion, RemuneracionActiva
                FROM Remuneraciones
                WHERE RemuneracionId = @RemuneracionId", new {remuneracionId});
        }

        public async Task EditarRemuneracion(Remuneracion remuneracion)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Remuneraciones
                SET RemuneracionDescripcion = @RemuneracionDescripcion, RemuneracionActiva = @RemuneracionActiva
                WHERE RemuneracionId = @RemuneracionId", remuneracion);
        }

        public async Task EliminarRemuneracion(int remuneracionId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE Remuneraciones
                WHERE RemuneracionId = @RemuneracionId", new {remuneracionId});
        }

    }
}
