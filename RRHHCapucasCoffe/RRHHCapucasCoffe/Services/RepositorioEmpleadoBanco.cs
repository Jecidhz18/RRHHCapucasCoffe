using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.EmpleadosBancos;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEmpleadoBanco : IRepositorioEmpleadoBanco
    {
        private readonly string connectionString;
        public RepositorioEmpleadoBanco(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearEmpleadoBanco(List<EmpleadoBanco> empleadoBancos, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var empleadoBanco in empleadoBancos)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO EmpleadosBancos (EmpleadoId, BancoId, EmpleadoBancoNoCuenta, EmpleadoBancoActiva)
                    VALUES (@EmpleadoId, @BancoId, @EmpleadoBancoNoCuenta, @EmpleadoBancoActiva)", new
                    {
                        empleadoId,
                        empleadoBanco.BancoId,
                        empleadoBanco.EmpleadoBancoNoCuenta,
                        empleadoBanco.EmpleadoBancoActiva
                    });
            }
        }

        public async Task<IEnumerable<EmpleadoBancoViewModel>> ObtenerEmpleadoBancoPorEmpleadoId(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EmpleadoBancoViewModel>(
                @"SELECT eb.EmpleadoBancoId, eb.BancoId, b.BancoNombre, eb.EmpleadoBancoNoCuenta, eb.EmpleadoBancoActiva
                FROM EmpleadosBancos eb
                INNER JOIN Bancos b ON b.BancoId = eb.BancoId
                WHERE EmpleadoId = @EmpleadoId", new { empleadoId });
        }
    }
}

