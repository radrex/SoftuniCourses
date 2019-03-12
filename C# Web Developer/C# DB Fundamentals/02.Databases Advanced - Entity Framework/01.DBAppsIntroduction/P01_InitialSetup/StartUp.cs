using System;
using System.Data.SqlClient;

namespace P01_InitialSetup
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

             //-------------EXEC COMMAND, NonQuery - CREATE, INSERT, DELETE --------------------
                //-------- CREATE DATABASE --------
                string createDatabase = "CREATE DATABASE MinionsDB";
                using (SqlCommand command = new SqlCommand(createDatabase, connection))
                {
                    command.ExecuteNonQuery();
                }         
            }
        }
    }
}
