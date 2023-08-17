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

            foreach (var departamentoId in deptoMunicipio.DepartamentoId)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpDeptosMpios (DepartamentoId, MunicipioId)
                    VALUES (@DepartamentoId, @MunicipioId)", new {municipioId = deptoMunicipio.MunicipioId, departamentoId});
            }
        }

    }
}
