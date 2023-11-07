using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.DireccionesEmpleados;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDireccionEmpleado : IRepositorioDireccionEmpleado
    {
        private readonly string connectionString;

        public RepositorioDireccionEmpleado(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> CrearDireccionEmpleado(DireccionEmpleado direccionEmpleado)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QuerySingleAsync<int>(
                @"INSERT INTO DireccionesEmpleados (PaisId, DepartamentoId, MunicipioId, AldeaId)
                VALUES (@PaisId, @DepartamentoId, @MunicipioId, @AldeaId)
                SELECT SCOPE_IDENTITY()", direccionEmpleado);
        }

        public async Task<int> ExisteDireccionEmpleado(DireccionEmpleado direccionEmpleado)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT DireccionEmpleadoId FROM DireccionesEmpleados
                WHERE PaisId = @PaisId AND DepartamentoId = @DepartamentoId AND MunicipioId = @MunicipioId AND (AldeaId = @AldeaId OR AldeaId IS NULL)", direccionEmpleado);
        }

        public async Task<DireccionEmpleadoNacimiento> ObtenerDireccionEmpleadoNacPorId(int direccionEmpleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<DireccionEmpleadoNacimiento>(
                @"SELECT * FROM DireccionesEmpleados
                WHERE DireccionEmpleadoId = @DireccionEmpleadoId", new { direccionEmpleadoId });
        }

        public async Task<DireccionEmpleadoResidencia> ObtenerDireccionEmpleadoResPorId(int direccionEmpleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<DireccionEmpleadoResidencia>(
                @"SELECT * FROM DireccionesEmpleados
                WHERE DireccionEmpleadoId = @DireccionEmpleadoId", new { direccionEmpleadoId });
        }

        public async Task EditarDireccionNacimientoEmpleado(DireccionEmpleadoNacimiento direccionEmpleadoNacimiento)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE DireccionesEmpleados
                SET PaisId = @PaisId, DepartamentoId = @DepartamentoId, MunicipioId = @MunicipioId, AldeaId = @AldeaId
                WHERE DireccionEmpleadoId = @DireccionEmpleadoId", direccionEmpleadoNacimiento);
        }

        public async Task EditarDireccionResidenciaEmpleado(DireccionEmpleadoResidencia direccionEmpleadoResidencia )
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE DireccionesEmpleados
                SET PaisId = @PaisId, DepartamentoId = @DepartamentoId, MunicipioId = @MunicipioId, AldeaId = @AldeaId
                WHERE DireccionEmpleadoId = @DireccionEmpleadoId", direccionEmpleadoResidencia);
        }

        public async Task EliminarDireccionEmpleado(int direccionEmpleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM DireccionesEmpleados
                WHERE DireccionEmpleadoId = @DireccionEmpleadoId", new { direccionEmpleadoId });
        }
    }
}
