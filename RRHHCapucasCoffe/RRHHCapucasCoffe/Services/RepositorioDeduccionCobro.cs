using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

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
    }
}
