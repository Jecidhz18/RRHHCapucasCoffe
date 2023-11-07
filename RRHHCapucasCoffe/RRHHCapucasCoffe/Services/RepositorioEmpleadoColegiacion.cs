using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.EmpleadosColegiaciones;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEmpleadoColegiacion : IRepositorioEmpleadoColegiacion
    {
        private readonly string connectionString;

        public RepositorioEmpleadoColegiacion(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CrearEmpleadoColegiacion(List<EmpleadoColegiacion> empleadoColegiaciones, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var empleadoColegiacion in empleadoColegiaciones)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO EmpleadosColegiaciones 
                        (EmpleadoId, ColegioProfesionalId, EmpleadoColegiacionAnio, EmpleadoColegiacionCuota, EmpleadoColegiacionActivo)
                    VALUES (@EmpleadoId, @ColegioProfesionalId, @EmpleadoColegiacionAnio, @EmpleadoColegiacionCuota, @EmpleadoColegiacionActivo)", new
                    {
                        empleadoId, 
                        empleadoColegiacion.ColegioProfesionalId,
                        empleadoColegiacion.EmpleadoColegiacionAnio,
                        empleadoColegiacion.EmpleadoColegiacionCuota,
                        empleadoColegiacion.EmpleadoColegiacionActivo
                    });
            }
        }

        public async Task<IEnumerable<EmpleadoColegiacionViewModel>> ObtenerEmpleadoColegiacionPorEmpleadoId(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EmpleadoColegiacionViewModel>(
                @"SELECT ec.EmpleadoColegiacionId, ec.ColegioProfesionalId, cp.ColegioProfesionalNombre, ec.EmpleadoColegiacionAnio,
                    ec.EmpleadoColegiacionCuota, ec.EmpleadoColegiacionActivo
                FROM EmpleadosColegiaciones ec
                INNER JOIN ColegiosProfesionales cp ON cp.ColegioProfesionalId = ec.ColegioProfesionalId
                WHERE ec.EmpleadoId = @EmpleadoId", new { empleadoId });
        }

        public async Task EliminarEmpleadoColegiacion(int[] empleadoColegiacionIds, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE EmpleadosColegiaciones
                WHERE EmpleadoColegiacionId NOT IN @EmpleadoColegiacionIds AND EmpleadoId = @EmpleadoId", new { empleadoColegiacionIds, empleadoId });
        }

        public async Task EditarEmpleadoColegiacion(List<EmpleadoColegiacion> empleadoColegiaciones, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var empleadoColegiacion in empleadoColegiaciones)
            {
                await connection.ExecuteAsync(
                    @"UPDATE EmpleadosColegiaciones
                    SET EmpleadoColegiacionAnio = @EmpleadoColegiacionAnio, EmpleadoColegiacionCuota = @EmpleadoColegiacionCuota,
                        EmpleadoColegiacionActivo = @EmpleadoColegiacionActivo
                    WHERE EmpleadoColegiacionId = @EmpleadoColegiacionId AND EmpleadoId = @EmpleadoId", new
                    {       
                        empleadoColegiacion.EmpleadoColegiacionId,
                        EmpleadoId = empleadoId,
                        empleadoColegiacion.ColegioProfesionalId,
                        empleadoColegiacion.EmpleadoColegiacionAnio,
                        empleadoColegiacion.EmpleadoColegiacionCuota,
                        empleadoColegiacion.EmpleadoColegiacionActivo
                    });
            }
        }

        public async Task EliminarEmpleadoColegiacion(int empleadoId)
        {
            await using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM EmpleadosColegiaciones
                WHERE EmpleadoId = @EmpleadoId", new { empleadoId });
        }
    }
}
