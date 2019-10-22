namespace P07_PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class P07_PrintAllMinionNames
    {
        static void Main(string[] args)
        {
            List<string> minions = new List<string>();
            List<string> arrangedMinions = new List<string>();

            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();
                SqlCommand command = new SqlCommand("SELECT Name FROM Minions", dbCon);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader["Name"]);
                    }
                }
            }

            while (minions.Count > 0)
            {
                arrangedMinions.Add(minions[0]);
                minions.RemoveAt(0);

                if (minions.Count > 0)
                {
                    arrangedMinions.Add(minions[minions.Count - 1]);
                    minions.RemoveAt(minions.Count - 1);
                }
            }

            arrangedMinions.ForEach(m => Console.WriteLine(m));
        }
    }
}
