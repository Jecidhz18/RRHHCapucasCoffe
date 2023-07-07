using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Models;

namespace RRHHCapucasCoffe.Services
{
    public interface IRepositorioDepartamento
    {
       
    }
    public class RepositorioDepartamento : IRepositorioDepartamento
    {
        private readonly string connectionString;

        public RepositorioDepartamento(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //public async Task CrearDepartamento(Departamento departamento)
        //{
        //    using var connection = new SqlConnection(connectionString);
        //}
    }
}
