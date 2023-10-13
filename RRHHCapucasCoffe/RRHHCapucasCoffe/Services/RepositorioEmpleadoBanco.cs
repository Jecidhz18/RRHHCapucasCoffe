using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

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
    }
}

