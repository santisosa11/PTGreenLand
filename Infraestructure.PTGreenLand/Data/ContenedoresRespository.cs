using Core.PTGreenLand.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.PTGreenLand.Data
{
    public class ContenedoresRespository
    {
        private readonly string _connectionString;

        public ContenedoresRespository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Contenedores>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetContenedores", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Contenedores>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<List<Contenedores>> GetByCodigoNaviera(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetContenedoresxNaviera", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    var response = new List<Contenedores>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Contenedores MapToValue(SqlDataReader reader)
        {
            return new Contenedores()
            {
                Prefijo = reader["Prefijo"].ToString(),
                Numero = reader["Numero"].ToString(),
                DigitoControl = reader["DigitoControl"].ToString(),
                CodigoNaviera = (int)reader["CódigoNaviera"],
                NombreNaviera = reader["NombreNaviera"].ToString(),
                FechaFabricacion = (DateTime)reader["FechaFabricación"],
                Tara = (decimal)reader["Tara"]
            };
        }
    }
}
