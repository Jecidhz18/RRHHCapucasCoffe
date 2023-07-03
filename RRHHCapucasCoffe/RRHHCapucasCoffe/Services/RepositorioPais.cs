using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Models;

namespace RRHHCapucasCoffe.Services
{
    public interface IRepositorioPais
    {
        Task CrearPais(Pais pais);
        Task<bool> ExistePais(string paisNombre);
        Task<IEnumerable<Pais>> ObtenerPais();
    }
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
                @"INSERT INTO Paises (PaisNombre, PaisActivo) 
                VALUES (@PaisNombre, @PaisActivo) 
                SELECT SCOPE_IDENTITY();", pais);

            pais.PaisId = id;   
        }

        public async Task<bool> ExistePais(string paisNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var exitePais = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Paises WHERE PaisNombre = @PaisNombre;", new {paisNombre});

            return exitePais == 1;
        }

        public async Task<IEnumerable<Pais>> ObtenerPais()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Pais>(@"SELECT PaisId, PaisNombre, PaisActivo
                                                            FROM Paises");
        }
    }
}
