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
    public class NavierasRepository
    {
        private readonly string _connectionString;

        public NavierasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Navieras>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetNavieras", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Navieras>();
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

        private Navieras MapToValue(SqlDataReader reader)
        {
            return new Navieras()
            {
                Codigo = (int)reader["Código"],
                Nombre = reader["Nombre"].ToString(),
                Telefono = reader["Teléfono"].ToString(),
                Estado = (int)reader["Estado"]
            };
        }
    }
}
