using System;
using System.Data.SqlClient;

namespace P02_VillianNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
             //------------- EXEC COMMAND, Reader - FOREACH on result set from query -------------------
                //--------- PRINT VILLIANS AND THEIR MINIONS ---------
                string villianNamesMinions = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
                             "FROM Villains AS v " +
                             "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                             "GROUP BY v.Id, v.Name " +
                             "HAVING COUNT(mv.VillainId) > 3 " +
                             "ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(villianNamesMinions, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            string villianName = (string)reader["Name"];
                            int minionsCount = (int)reader["MinionsCount"];

                            Console.WriteLine($"{villianName} - {minionsCount}");
                        }
                    }
                }
            }
        }
    }
}
