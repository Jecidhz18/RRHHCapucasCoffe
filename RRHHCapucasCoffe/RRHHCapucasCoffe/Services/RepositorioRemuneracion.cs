using Dapper;
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


    }
}
