using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.EmpleadosAreas;
using System.Data.Common;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEmpleadoArea : IRepositorioEmpleadoArea
    {
        private readonly string connectionString;

        public RepositorioEmpleadoArea(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CrearEmpleadoArea(List<EmpleadoArea> empleadoAreas, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach(var empleadoArea in empleadoAreas)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO EmpleadosAreas (EmpleadoId, UnidadId, AgenciaId, EmpleadoAreaActivo)
                    VALUES (@EmpleadoId, @UnidadId, @AgenciaId, @EmpleadoAreaActivo)", new
                    {
                        empleadoId,
                        empleadoArea.UnidadId,
                        empleadoArea.AgenciaId,
                        empleadoArea.EmpleadoAreaActivo
                    });
            }
        }
        public async Task<IEnumerable<EmpleadoAreaViewModel>> ObtenerEmpleadoAreaPorEmpleadoId(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EmpleadoAreaViewModel>(
                @"SELECT ea.EmpleadoAreaId, ea.AgenciaId, a.AgenciaNombre, ea.UnidadId, u.UnidadDescripcion, ea.EmpleadoAreaActivo
                FROM EmpleadosAreas ea 
                INNER JOIN Agencias a ON a.AgenciaId = ea.AgenciaId
                INNER JOIN Unidades u ON u.UnidadId = ea.UnidadId
                WHERE ea.EmpleadoId = @EmpleadoId", new { empleadoId });

        }
        public async Task EliminarEmpleadoArea(int[] empleadoAreaIds, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE EmpleadosAreas
                WHERE EmpleadoAreaId NOT IN @EmpleadoAreaIds AND EmpleadoId = @EmpleadoId", new 
                {
                    EmpleadoAreaIds = empleadoAreaIds, 
                    EmpleadoId = empleadoId
                });
        }

        public async Task EditarEmpleadoArea(List<EmpleadoArea> empleadoAreas, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var empleadoArea in empleadoAreas)
            {
                await connection.ExecuteAsync(
                @"UPDATE EmpleadosAreas
                SET UnidadId = @UnidadId, AgenciaId = @AgenciaId,
                    EmpleadoAreaActivo = @EmpleadoAreaActivo
                WHERE EmpleadoAreaId = @EmpleadoAreaId AND EmpleadoId = @EmpleadoId", new
                {
                    empleadoArea.EmpleadoAreaId,
                    EmpleadoId = empleadoId,
                    empleadoArea.UnidadId,
                    empleadoArea.AgenciaId,
                    empleadoArea.EmpleadoAreaActivo
                }); 
            }
        }
    }
}
