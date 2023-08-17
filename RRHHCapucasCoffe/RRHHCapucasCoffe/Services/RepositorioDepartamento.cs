using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDepartamento : IRepositorioDepartamento
    {
        private readonly string connectionString;

        public RepositorioDepartamento(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearDepartamento(DeptoViewModel departamento)
        {
            using var connection = new SqlConnection(connectionString);

            int departamentoId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO DpDepartamentos (DepartamentoNombre, DepartamentoActivo)
                VALUES (@DepartamentoNombre, @DepartamentoActivo)
                SELECT SCOPE_IDENTITY();", departamento);

            departamento.DepartamentoId = departamentoId;
        }

        //Validacion si existe el departamento y sus referencias
        public async Task<bool> ExisteDepartamento(string departamentoNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeDepartamento = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM DpDepartamentos
                WHERE DepartamentoNombre = @DepartamentoNombre", new {departamentoNombre});

            return existeDepartamento == 1;
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamento()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Departamento>(
                @"SELECT DepartamentoId, DepartamentoNombre, DepartamentoActivo
                FROM DpDepartamentos");
        }

        public async Task<Departamento> ObtenerDepartamentoPorId(int departamentoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Departamento>(
                @"SELECT DepartamentoId, DepartamentoNombre, DepartamentoActivo
                FROM DpDepartamentos
                WHERE DepartamentoId = @DepartamentoId", new {departamentoId});
        }

        public async Task EditarDepartamento(Departamento departamento)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE DpDepartamentos
                SET DepartamentoNombre = @DepartamentoNombre, DepartamentoActivo = @DepartamentoActivo
                WHERE DepartamentoId = @DepartamentoId", departamento);
        }

        public async Task EliminarDepartamento(int departamentoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE DpDepartamentos
                WHERE DepartamentoId = @DepartamentoId", new { departamentoId });
        }

        public async Task<IEnumerable<Departamento>> ObtenerDeptoActivoPorPais(Pais pais)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Departamento>(
                @"SELECT d.DepartamentoId, DepartamentoNombre, DepartamentoActivo
                FROM DpDepartamentos d
                INNER JOIN DpPaisesDeptos pd ON d.DepartamentoId = pd.DepartamentoId
                WHERE pd.PaisId = @PaisId AND DepartamentoActivo = '1'", new {pais.PaisId});
        }
    }
}
