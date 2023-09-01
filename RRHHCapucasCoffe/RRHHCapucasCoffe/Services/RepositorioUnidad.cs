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
                @"INSERT INTO Unidades (UnidadDescripcion, UnidadActiva, UnidadUsuarioGrabo, UnidadFechaGrabo)
                VALUES (@UnidadDescripcion, @UnidadActiva, @UnidadUsuarioGrabo, @UnidadFechaGrabo)", unidad);
        }

        public async Task<bool> ExisteUnidad(string unidadDescripcion)
        {
            using var connection = new SqlConnection(connectionString);

            var existeUnidad = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Unidades 
                WHERE UnidadDescripcion = @UnidadDescripcion", new { unidadDescripcion });

            return existeUnidad == 1;
        }

        public async Task<IEnumerable<UnidadViewModel>> ObtenerUnidad()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<UnidadViewModel>(
                @"SELECT u.UnidadId, u.UnidadDescripcion, u.UnidadActiva,
                         u.UnidadUsuarioGrabo, ug.UsuarioCuenta AS UUsuarioGrabo, u.UnidadFechaGrabo,
                         u.UnidadUsuarioModifico, um.UsuarioCuenta AS UUsuarioModifico, u.UnidadFechaModifico
                FROM Unidades u
                INNER JOIN Usuarios ug ON ug.UsuarioId = u.UnidadUsuarioGrabo
                LEFT JOIN Usuarios um ON um.UsuarioId = u.UnidadUsuarioModifico");
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
