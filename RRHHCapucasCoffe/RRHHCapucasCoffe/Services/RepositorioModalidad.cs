using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioModalidad : IRepositorioModalidad
    {
        private readonly string connectionString;

        public RepositorioModalidad(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearModalidad(Modalidad modalidad)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"INSERT INTO Modalidades (ModalidadNombre, ModalidadDescripcion, ModalidadActiva)
                VALUES (@ModalidadNombre, @ModalidadDescripcion, @ModalidadActiva)", modalidad);
        }

        public async Task<bool> ExisteModalidad(string modalidadNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeModalidad = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Modalidades
                WHERE ModalidadNombre = @ModalidadNombre", new {modalidadNombre});

            return existeModalidad == 1;
        }

        public async Task<IEnumerable<Modalidad>> ObtenerModalidades()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Modalidad>(
                @"SELECT * FROM Modalidades");
        }

        public async Task<Modalidad> ObtenerModalidaPorId(int modalidadId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Modalidad>(
                @"SELECT * FROM Modalidades
                WHERE ModalidadId = @ModalidadId", new { modalidadId });
        }

        public async Task EditarModalidad(Modalidad modalidad)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Modalidades
                SET ModalidadNombre = @ModalidadNombre, ModalidadDescripcion = @ModalidadDescripcion, ModalidadActiva = @ModalidadActiva
                WHERE ModalidadId = @ModalidadId", modalidad);
        }

        public async Task<IEnumerable<Modalidad>> ObtenerModalidadesActivas()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Modalidad>(
                @"SELECT * FROM Modalidades
                WHERE ModalidadActiva = '1'");
        }
    }
}
