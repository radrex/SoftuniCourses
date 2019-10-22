namespace P02_VillainNames
{
    using System;
    using System.Data.SqlClient;

    class P02_VillainNames
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();
                string select = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
                                "FROM Villains AS v " +
                                "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                                "GROUP BY v.Id, v.Name " +
                                "HAVING COUNT(mv.VillainId) > 3 " +
                                "ORDER BY COUNT(mv.VillainId)";

                SqlCommand command = new SqlCommand(select, dbCon);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }
            }
        }
    }
}
