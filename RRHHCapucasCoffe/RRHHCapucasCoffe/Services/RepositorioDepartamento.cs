using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;

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
                @"INSERT INTO Departamentos (DepartamentoNombre, DepartamentoActivo)
                VALUES (@DepartamentoNombre, @DepartamentoActivo)
                SELECT SCOPE_IDENTITY();", departamento);

            departamento.DepartamentoId = departamentoId;
        }

        //Validacion si existe el departamento y sus referencias
        public async Task<bool> ExisteDepartamento(string departamentoNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeDepartamento = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Departamentos
                WHERE DepartamentoNombre = @DepartamentoNombre", new {departamentoNombre});

            return existeDepartamento == 1;
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamento()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Departamento>(@"SELECT DepartamentoId, DepartamentoNombre, DepartamentoActivo
                                                            FROM Departamentos");
        }

        public async Task<Departamento> ObtenerDepartamentoPorId(int departamentoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Departamento>(
                @"SELECT DepartamentoId, DepartamentoNombre, DepartamentoActivo
                FROM Departamentos
                WHERE DepartamentoId = @DepartamentoId", new {departamentoId});
        }

        public async Task EditarDepartamento(Departamento departamento)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Departamentos
                SET DepartamentoNombre = @DepartamentoNombre, DepartamentoActivo = @DepartamentoActivo
                WHERE DepartamentoId = @DepartamentoId", departamento);
        }

        public async Task EliminarDepartamento(int departamentoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE Departamentos
                WHERE DepartamentoId = @DepartamentoId", new { departamentoId });
        }
    }
}
