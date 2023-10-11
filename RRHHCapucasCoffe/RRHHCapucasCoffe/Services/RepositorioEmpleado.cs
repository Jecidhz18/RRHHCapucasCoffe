using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly string connectionString;

        public RepositorioEmpleado(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> ExisteEmpleado(string empleadoIdentificacion)
        {
            using var connection = new SqlConnection(connectionString);

            var existeEmpleado = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Empleados
                WHERE EmpleadoIdentificacion = @EmpleadoIdentificacion", new { empleadoIdentificacion });

            return existeEmpleado == 1;
        }

    }
}
