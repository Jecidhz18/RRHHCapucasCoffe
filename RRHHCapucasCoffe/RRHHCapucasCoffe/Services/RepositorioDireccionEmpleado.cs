using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

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
    }
}
