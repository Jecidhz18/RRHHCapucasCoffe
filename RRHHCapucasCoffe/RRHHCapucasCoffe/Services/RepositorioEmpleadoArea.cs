using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
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
    }
}
