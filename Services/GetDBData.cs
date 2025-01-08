using Microsoft.Data.SqlClient;
using System.Data;

namespace MessengerMvcApp.Services
{
    public class GetDBData
    {
        public DataTable SelectData(string query, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MessengerDataString");
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataSet, "UserDetails");
                    dataTable = dataSet.Tables["UserDetails"];
                }
            }

            return dataTable;
        }
    }
}