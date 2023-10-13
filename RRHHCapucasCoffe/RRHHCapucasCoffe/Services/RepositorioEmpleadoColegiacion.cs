using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

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
    }
}
