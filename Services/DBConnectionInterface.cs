using MessengerMvcApp.Models;
using Microsoft.Data.SqlClient;

namespace MessengerMvcApp.Services
{
    public interface DBConnectionInterface
    {
        public List<ChatsModel> GetDatabaseInfo(string query, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MessengerDataString");

            List<ChatsModel> chats = new List<ChatsModel>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = "select UserName,EmailID,Conversation from UserDetails";

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                }

                return chats;
            }
        }
    }
