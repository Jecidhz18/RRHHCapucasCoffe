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

        public async Task InsertarPaisDepto(DeptoCrearViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < deptoPais.PaisId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpPaisesDeptos (PaisId, DepartamentoId)
                    VALUES (@PaisId, @DepartamentoId)",
                    new { PaisId = deptoPais.PaisId[i], deptoPais.DepartamentoId });
            }
        }

        public async Task EliminarPaisDeptoPorDepto(DeptoEditarViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM DpPaisesDeptos
                WHERE DepartamentoId = @DepartamentoId", new {deptoPais.DepartamentoId});
        }

        public async Task InsertarPaisDeptoPorDepto(DeptoEditarViewModel deptoPais)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < deptoPais.PaisId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpPaisesDeptos (PaisId, DepartamentoId)
                    VALUES (@PaisId, @DepartamentoId)",
                    new {PaisId = deptoPais.PaisId[i], deptoPais.DepartamentoId});
            }
        }

        //public async Task EliminarPaisDepto(DeptoViewModel deptoPais)
        //{
        //    using var connection = new SqlConnection(connectionString);

        //    foreach (var paisId in deptoPais.PaisId)
        //    {
        //        await connection.ExecuteAsync(
        //            @"DELETE FROM DpPaisesDeptos
        //            WHERE PaisId IN @PaisId
        //            AND DepartamentoId = @DepartamentoId;", new { deptoPais.PaisId, deptoPais.DepartamentoId });
        //    }
        //}
    }
}
