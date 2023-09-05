using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Municipios;
using RRHHCapucasCoffe.Models.TablasUniones;

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

        public async Task<IEnumerable<Municipio>> ObtenerMunicipio()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Municipio>(
                @"SELECT MunicipioId, MunicipioNombre, MunicipioActivo
                FROM DpMunicipios");
        }

        public async Task<Municipio> ObtenerMunicipioPorId(int municipioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Municipio>(
                @"Select MunicipioId, MunicipioNombre, MunicipioActivo
                From DpMunicipios
                WHERE MunicipioId = @MunicipioId", new { municipioId });
        }

        public async Task EditarMunicipio(MunicipioEditarViewModel municipio)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE DpMunicipios
                SET MunicipioNombre = @MunicipioNombre, MunicipioActivo = @MunicipioActivo
                WHERE MunicipioId = @MunicipioId", municipio);
        }

        public async Task<IEnumerable<Municipio>> ObtenerMunicipioActivoPorDepto(PaisDepto paisDepto)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Municipio>(
                @"SELECT m.MunicipioId, m.MunicipioNombre, m.MunicipioActivo
                FROM DpMunicipios m
                INNER JOIN DpDeptosMpios dm ON m.MunicipioId = dm.MunicipioId
                WHERE dm.PaisId = @PaisId AND  dm.DepartamentoId = @DepartamentoId AND m.MunicipioActivo = '1'",
                new { paisDepto.PaisId, paisDepto.DepartamentoId });
        }
    }
}
