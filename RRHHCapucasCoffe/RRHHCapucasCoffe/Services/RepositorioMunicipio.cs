using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly string connectionString;

        public RepositorioMunicipio(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearMunicipio(Municipio municipio)
        {
            using var connection = new SqlConnection(connectionString);

            var municipioId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO DpMunicipios (MunicipioNombre, MunicipioActivo)
                VALUES (@MunicipioNombre, @MunicipioActivo)
                SELECT SCOPE_IDENTITY();", municipio);

            municipio.MunicipioId = municipioId;
        }

        public async Task<bool> ExisteMunicipio(string municipioNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeMunicipio = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM DpMunicipios
                WHERE MunicipioNombre = @MunicipioNombre", new {municipioNombre});

            return existeMunicipio == 1;
        }

        public async Task<Municipio> ObtenerMunicipioPorId(int municipioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Municipio>(
                @"Select MunicipioId, MunicipioNombre, MunicipioActivo
                From DpMunicipios
                WHERE MunicipioId = @MunicipioId", new { municipioId });
        }
    }
}
