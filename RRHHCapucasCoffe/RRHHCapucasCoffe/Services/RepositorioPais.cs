using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioPais : IRepositorioPais
    {
        private readonly string connectionString;
        public RepositorioPais(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearPais(Pais pais)
        {
            using var connetion = new SqlConnection(connectionString);

            var id = await connetion.QuerySingleAsync<int>(
                @"INSERT INTO DpPaises (PaisNombre, PaisActivo) 
                VALUES (@PaisNombre, @PaisActivo) 
                SELECT SCOPE_IDENTITY();", pais);

            pais.PaisId = id;   
        }

        public async Task<bool> ExistePais(string paisNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var exitePais = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM DpPaises WHERE PaisNombre = @PaisNombre;", new {paisNombre});

            return exitePais == 1;
        }

        public async Task<IEnumerable<Pais>> ObtenerPais()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Pais>(@"SELECT PaisId, PaisNombre, PaisActivo
                                                            FROM DpPaises");
        }

        public async Task ActualizarPais(Pais pais)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE DpPaises 
                                            SET PaisNombre = @PaisNombre, PaisActivo = @PaisActivo
                                            WHERE PaisId = @PaisId", pais);
        }

        public async Task<Pais> ObtenerPaisPorId(int paisId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Pais>(@"
                            SELECT PaisId, PaisNombre, PaisActivo 
                            FROM DpPaises WHERE PaisId = @PaisId", new {paisId});
        }

        public async Task EliminarPais(int paisId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(@"DELETE DpPaises WHERE PaisId = @PaisId", new {paisId});
        }

        public async Task<IEnumerable<Pais>> ObtenerPaisActivo()
        {
            using var connection = new SqlConnection(connectionString);
            
            return await connection.QueryAsync<Pais>(
                @"SELECT PaisId, PaisNombre, PaisActivo
                FROM DpPaises
                WHERE PaisActivo = '1'");
        }

        public async Task<IEnumerable<Pais>> ObtenerPaisPorDepto(int departamentoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Pais>(
                @"SELECT P.PaisId, P.PaisNombre, P.PaisActivo
                FROM DpPaises AS P
                JOIN DpPaisesDeptos AS PD ON P.PaisId = PD.PaisId
                JOIN DpDepartamentos AS D ON PD.DepartamentoId = D.DepartamentoId
                WHERE D.DepartamentoId = @DepartamentoId;", new {departamentoId});
        }
    }
}
