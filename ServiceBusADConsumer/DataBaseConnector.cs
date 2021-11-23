using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusADConsumer
{
    public class DataBaseConnector
    {
        public async Task CreateUsersInDB(User user)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
          
            await using (SqlCommand insertUser = new SqlCommand($"INSERT INTO USERS (Name, AzureId) VALUES ({user.Name}, {user.AzureAdId})", conn))
            {
                insertUser.ExecuteNonQuery(); //execute the Query
                Console.WriteLine("User: " + user.Name + " cadastrado no banco");
            }
        }
    }
}
