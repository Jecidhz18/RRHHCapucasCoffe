using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using System.Runtime.CompilerServices;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDeduccionCobro : IRepositorioDeduccionCobro
    {
        private readonly string connectionString;

        public RepositorioDeduccionCobro(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearDeduccionCobro(List<DeduccionCobro> deduccionCobros, int deduccionId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach( var deduccionCobro in deduccionCobros)
            {
                await connection.QuerySingleAsync(
                @"INSERT INTO DeduccionesCobros (DeduccionId, DeduccionCobroDesde, DeduccionCobroHasta, DeduccionCobroPorcentaje, DeduccionCobroMonto)
                VALUES (@DeduccionId, @DeduccionCobroDesde, @DeduccionCobroHasta, @DeduccionCobroPorcentaje, @DeduccionCobroMonto)
                SELECT SCOPE_IDENTITY();", new
                {
                    deduccionId,
                    deduccionCobro.DeduccionCobroDesde,
                    deduccionCobro.DeduccionCobroHasta,
                    deduccionCobro.DeduccionCobroPorcentaje,
                    deduccionCobro.DeduccionCobroMonto
                });
            }
        }

        public async Task<IEnumerable<DeduccionCobro>> ObtenerDeduccionCobrosPorDeduccionId(int deduccionId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<DeduccionCobro>(
                @"SELECT * FROM DeduccionesCobros
                WHERE DeduccionId = @DeduccionId", new { deduccionId });
        }

        public async Task EliminarDeduccionCobro(int[] deduccionCobroIds, int deduccionId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE DeduccionesCobros
                WHERE DeduccionCobroId NOT IN @DeduccionCobroIds AND DeduccionId = @DeduccionId", new
                {
                    deduccionCobroIds, 
                    deduccionId
                });
        }

        public async Task EditarDeduccionCobro(List<DeduccionCobro> deduccionCobros, int deduccionId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var deduccionCobro in deduccionCobros)
            {
                await connection.ExecuteAsync(
                    @"UPDATE DeduccionesCobros
                    SET DeduccionCobroDesde = @DeduccionCobroDesde, DeduccionCobroHasta = @DeduccionCobroHasta,
                        DeduccionCobroPorcentaje = @DeduccionCobroPorcentaje, DeduccionCobroMonto = @DeduccionCobroMonto
                    WHERE DeduccionCobroId = @DeduccionCobroId AND DeduccionId = @DeduccionId", new
                    {
                        deduccionCobro.DeduccionCobroId,
                        deduccionId,
                        deduccionCobro.DeduccionCobroDesde,
                        deduccionCobro.DeduccionCobroHasta,
                        deduccionCobro.DeduccionCobroPorcentaje,
                        deduccionCobro.DeduccionCobroMonto
                    });
            }
        }

        public async Task EliminarDeduccionCobro(int deduccionId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM DeduccionesCobros
                WHERE DeduccionId = @DeduccionId", new { deduccionId });
        }
    }
}
