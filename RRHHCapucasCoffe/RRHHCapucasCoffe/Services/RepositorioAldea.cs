using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Aldeas;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioAldea : IRepositorioAldea
    {
        private readonly string connectionString;

        public RepositorioAldea(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearAldea(AldeaCrearViewModel aldea)
        {
            using var connection = new SqlConnection(connectionString);

            var aldeaId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO DpAldeas (AldeaNombre, AldeaActivo)
                VALUES (@AldeaNombre, @AldeaActivo)
                SELECT SCOPE_IDENTITY();", aldea);

            aldea.AldeaId = aldeaId;
        }

        public async Task<bool> ExisteAldea(string aldeaNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeAldea = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM DpAldeas
                WHERE AldeaNombre = @AldeaNombre", new { aldeaNombre });

            return existeAldea == 1;
        }

        public async Task<IEnumerable<Aldea>> ObtenerAldeas()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Aldea>(
                @"SELECT AldeaId, AldeaNombre, AldeaActivo
                FROM DpAldeas");
        }
    }
}
