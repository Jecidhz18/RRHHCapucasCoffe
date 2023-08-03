using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioPaisDepto : IRepositorioPaisDepto
    {
        private readonly string connectionString;

        public RepositorioPaisDepto(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertarPaisDepto(DeptoViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var paisId in deptoPais.PaisId)
            {
                if (paisId != null)
                {
                    await connection.ExecuteAsync(
                        @"INSERT INTO DpPaisesDeptos (PaisId, DepartamentoId)
                        VALUES (@PaisId, @DepartamentoId)", new { departamentoId = deptoPais.DepartamentoId, paisId });
                }
            }
        }

        public async Task EliminarPaisDeptoPorDepto(DeptoViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var paisId in deptoPais.PaisId)
            {
                await connection.ExecuteAsync(
                    @"DELETE FROM DpPaisesDeptos
                    WHERE PaisId NOT IN @PaisId
                    AND DepartamentoId = @DepartamentoId;", new {deptoPais.PaisId, deptoPais.DepartamentoId});
            }
        }

        public async Task InsertarPaisDeptoPorDepto(DeptoViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            foreach ( var paisId in deptoPais.PaisId)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO PdPaisesDeptos (PaisId, DepartamentoId)
                    SELECT @PaisId, @DepartamentoId
                    WHERE NOT EXISTS (
                    SELECT 1
                    FROM PdPaisesDeptos
                    WHERE PaisId = @PaisId AND DepartamentoId = @DepartamentoId)",
                    new { PaisId = paisId, DepartamentoId = deptoPais.DepartamentoId });
            }
        }

        public async Task EliminarPaisDepto(DeptoViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var paisId in deptoPais.PaisId)
            {
                await connection.ExecuteAsync(
                    @"DELETE FROM DpPaisesDeptos
                    WHERE PaisId IN @PaisId
                    AND DepartamentoId = @DepartamentoId;", new { deptoPais.PaisId, deptoPais.DepartamentoId });
            }
        }
    }
}
