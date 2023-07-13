using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDepartamento : IRepositorioDepartamento
    {
        private readonly string connectionString;

        public RepositorioDepartamento(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearDepartamento(Departamento departamento)
        {
            using var connection = new SqlConnection(connectionString);

            int departamentoId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Departamentos (DepartamentoNombre, DepartamentoActivo)
                VALUES (@DepartamentoNombre, @DepartamentoActivo)
                SELECT SCOPE_IDENTITY();", departamento);

            departamento.DepartamentoId = departamentoId;
;
        }

        //public async Task CrearReferencia(IEnumerable<PaisDepto>paises, int departamentoId)
        //{
        //    using var connection = new SqlConnection(connectionString);
          
        //    var query = "INSERT INTO PaisesDeptos (PaisId, DepartamentoId) VALUES (@PaisId, @DepartamentoId)";

        //    var parametros = paises.Select(pais => new { PaisId = pais.PaisId, DepartamentoId = departamentoId });

        //    await connection.ExecuteAsync(query, parametros);
        //}

        public async Task<IEnumerable<Departamento>> ObtenerDepartamento()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Departamento>(@"SELECT DepartamentoId, DepartamentoNombre, DepartamentoActivo
                                                            FROM Departamentos");
        }

        //public async Task<int> ObtenerUltimoDepartamentoId()
        //{
        //    using var connection = new SqlConnection(connectionString);
        //    var query = "SELECT MAX(DepartamentoId) FROM Departamentos";

        //    var ultimoDepartamentoId = await connection.ExecuteScalarAsync<int?>(query);

        //    return ultimoDepartamentoId ?? 0;
        //}

        //public async Task CrearReferencia(IEnumerable<PaisDepto> paises, int departamentoId)
        //{
        //    using var connection = new SqlConnection(connectionString);

        //    var query = "INSERT INTO PaisesDeptos (PaisId, DepartamentoId) VALUES (@PaisId, @DepartamentoId)";

        //    var parametros = paises.Select(pais => new { PaisId = pais.PaisId, DepartamentoId = departamentoId });

        //    await connection.ExecuteAsync(query, parametros);
        //}
    }
}
