using Microsoft.Data.SqlClient;
using System.Data;

namespace MessengerMvcApp.Services
{
    public interface GetDBData
    {
        public DataSet SelectData(string query, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MessengerDataString");

            DataSet dataSet = new DataSet();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataSet, "UserDetails");
                }
            }

            return dataSet;
        }
    }
}
