using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Unidades;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioUnidad : IRepositorioUnidad
    {
        private readonly string connectionString;

        public RepositorioUnidad(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearUnidad(Unidad unidad)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.QueryFirstOrDefaultAsync(
                @"INSERT INTO Unidades (UnidadDescripcion, UnidadActiva, UnidadUsuarioGrabo, UnidadFechaGrabo, UnidadUsuarioModifico, UnidadFechaModifico)
                VALUES (@UnidadDescripcion, @UnidadActiva, @UnidadUsuarioGrabo, @UnidadFechaGrabo, @UnidadUsuarioModifico, @UnidadFechaModifico)", unidad);
        }

        public async Task<bool> ExisteUnidad(string unidadDescripcion)
        {
            using var connection = new SqlConnection(connectionString);

            var existeUnidad = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Unidades 
                WHERE UnidadDescripcion = @UnidadDescripcion", new { unidadDescripcion });

            return existeUnidad == 1;
        }

        public async Task<IEnumerable<Unidad>> ObtenerUnidad()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Unidad>(
                @"SELECT Unidades.UnidadId, Unidades.UnidadDescripcion, Unidades.UnidadActiva,
                    UG.UsuarioCuenta AS UsuarioGrabo, Unidades.UnidadFechaGrabo,
                    UM.UsuarioCuenta AS UsuarioModifico, Unidades.UnidadFechaModifico
                FROM Unidades
                INNER JOIN Usuarios UG ON UG.UsuarioId = Unidades.UnidadUsuarioGrabo
                INNER JOIN Usuarios UM ON UM.UsuarioId = Unidades.UnidadUsuarioModifico");
        }

        public async Task<Unidad> ObtenerUnidadPorId(int unidadId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Unidad>(
                @"SELECT UnidadId, UnidadDescripcion, UnidadActiva, UnidadUsuarioGrabo, UnidadFechaGrabo, UnidadUsuarioModifico, UnidadFechaModifico
                FROM Unidades
                WHERE UnidadId = @UnidadId", new {unidadId});
        }

        public async Task EditarUnidad(Unidad unidad)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(@"UPDATE Unidades
            SET UnidadDescripcion = @UnidadDescripcion, UnidadActiva = @UnidadActiva, 
            UnidadUsuarioModifico = @UnidadUsuarioModifico, UnidadFechaModifico = @UnidadFechaModifico
            WHERE UnidadId = @UnidadId", unidad);
        } 

        public async Task EliminarUnidad(int unidadId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE Unidades
                WHERE UnidadId = @UnidadId", new {unidadId});
        }
    }
}
