using System;
using System.Data.SqlClient;

namespace P06_RemoveVillain
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string villainName = string.Empty;
                string villainQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

                using (SqlCommand command = new SqlCommand(villainQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    villainName = (string)command.ExecuteScalar();

                    if(villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                int affectedRows = DeleteMinionsVillainsId(connection, id);
                DeleteVillainsById(connection, id);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        private static void DeleteVillainsById(SqlConnection connection, int id)
        {
            string deleteVillainQuery = "DELETE FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                command.ExecuteNonQuery();
            }

        }

        private static int DeleteMinionsVillainsId(SqlConnection connection, int id)
        {
            string deleteMinionVillainQuery = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteMinionVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                return command.ExecuteNonQuery();
            }
        }
    }
}
