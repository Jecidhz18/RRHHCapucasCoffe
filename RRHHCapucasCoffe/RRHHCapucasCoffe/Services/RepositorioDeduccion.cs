using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Deducciones;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDeduccion : IRepositorioDeduccion
    {
        private readonly string connectionString;

        public RepositorioDeduccion(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CrearDeduccion(Deduccion deduccion)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QuerySingleAsync<int>(
                @"INSERT INTO Deducciones (DeduccionDescripcion, DeduccionAplicacion, DeduccionTipoCobro, DeduccionActiva, DeduccionUsuarioGrabo, DeduccionFechaGrabo)
                VALUES (@DeduccionDescripcion, @DeduccionAplicacion, @DeduccionTipoCobro, @DeduccionActiva, @DeduccionUsuarioGrabo, @DeduccionFechaGrabo)
                SELECT SCOPE_IDENTITY();", deduccion);
        }

        public async Task<IEnumerable<DeduccionViewModel>> ObtenerDeduccion()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<DeduccionViewModel>(
                @"SELECT d.DeduccionId, d.DeduccionDescripcion, d.DeduccionAplicacion, d.DeduccionTipoCobro, d.DeduccionActiva, ug.UsuarioCuenta AS DUsuarioGrabo,
	                d.DeduccionFechaGrabo, ua.UsuarioCuenta AS DUsuarioModifico, d.DeduccionUsuarioModifico
                FROM Deducciones d
                INNER JOIN Usuarios ug ON ug.UsuarioId = d.DeduccionUsuarioGrabo
                LEFT JOIN Usuarios ua ON ua.UsuarioId = d.DeduccionUsuarioModifico");
        }

        public async Task<Deduccion> ObtenerDeduccionPorId(int deduccionId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Deduccion>(
                @"SELECT * FROM Deducciones
                WHERE DeduccionId = @DeduccionId", new { deduccionId });
        }

        public async Task EditarDeduccion(Deduccion deduccion)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Deducciones 
                SET DeduccionDescripcion = @DeduccionDescripcion, DeduccionActiva = @DeduccionActiva, DeduccionAplicacion = @DeduccionAplicacion,
                DeduccionTipoCobro = @DeduccionTipoCobro, DeduccionUsuarioModifico = @DeduccionUsuarioModifico,
                DeduccionFechaModifico = @DeduccionFechaModifico
                WHERE DeduccionId = @DeduccionId", deduccion);
        }
    }
}
