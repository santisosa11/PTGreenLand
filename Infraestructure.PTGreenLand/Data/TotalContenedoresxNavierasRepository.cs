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
    public class TotalContenedoresxNavierasRepository
    {
        private readonly string _connectionString;

        public TotalContenedoresxNavierasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<TotalContxNavieras>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetTotalContenedoresxNavieras", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<TotalContxNavieras>();
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

        private TotalContxNavieras MapToValue(SqlDataReader reader)
        {
            return new TotalContxNavieras()
            {
                NombreNaviera = reader["NombreNaviera"].ToString(),
                TotalContenedores = (int)reader["TotalContenedores"]
            };
        }
    }
}
