using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDeptoMunicipio : IRepositorioDeptoMunicipio
    {
        private readonly string connectionString;

        public RepositorioDeptoMunicipio(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertarDeptoMunicipio(MunicipioCrearViewModel deptoMunicipio)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < deptoMunicipio.PaisId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpDeptosMpios (PaisId, DepartamentoId, MunicipioId)
                    VALUES (@PaisId, @DepartamentoId, @MunicipioId)",
                    new { PaisId = deptoMunicipio.PaisId[i],DepartamentoId  = deptoMunicipio.DepartamentoId[i], deptoMunicipio.MunicipioId });
            }
        }

        public async Task<IEnumerable<PaisDeptoViewModel>> ObtenerPaisDeptoPorMpio(int municipioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<PaisDeptoViewModel>(
                @"SELECT dm.PaisId, PaisNombre, dm.DepartamentoId, DepartamentoNombre
                FROM DpDeptosMpios dm
                INNER JOIN DpPaises AS p ON dm.PaisId = p.PaisId
                INNER JOIN DpDepartamentos AS d ON dm.DepartamentoId = d.DepartamentoId
                WHERE dm.MunicipioId = @MunicipioId;", new {municipioId});
        }

        public async Task EliminarDeptoMpioPorMpio(MunicipioEditarViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM DpDeptosMpios
                WHERE MunicipioId = @MunicipioId",
                new { modelo.MunicipioId });
        }

        public async Task InsertarDeptoMunicipioEditar(MunicipioEditarViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < modelo.PaisId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpDeptosMpios (PaisId, DepartamentoId, MunicipioId)
                    VALUES (@PaisId, @DepartamentoId, @MunicipioId)",
                    new { PaisId = modelo.PaisId[i], DepartamentoId = modelo.DepartamentoId[i], modelo.MunicipioId });
            }
        }
    }
}
