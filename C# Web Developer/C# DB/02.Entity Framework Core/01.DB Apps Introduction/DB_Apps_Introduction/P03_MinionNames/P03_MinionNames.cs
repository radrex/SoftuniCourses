namespace P03_MinionNames
{
    using System;
    using System.Data.SqlClient;

    class P03_MinionNames
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();

                int id = int.Parse(Console.ReadLine());
                string select = $"SELECT Name FROM Villains WHERE Id = {id}";
                SqlCommand command = new SqlCommand(select, dbCon);
                
                string villain = (string)command.ExecuteScalar();
                if (String.IsNullOrEmpty(villain))
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }

                string minions = "SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum, m.Name, m.Age " +
                                 "FROM MinionsVillains AS mv " +
                                 "JOIN Minions As m ON mv.MinionId = m.Id " +
                                 "WHERE mv.VillainId = @Id " +
                                 "ORDER BY m.Name";
                command = new SqlCommand(minions, dbCon);
                command.Parameters.AddWithValue("@Id", id);

                bool hasMinions = false;
                Console.WriteLine($"Villian: {villain}");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                        hasMinions = true;
                    }
                }

                if (!hasMinions)
                {
                    Console.WriteLine("(no minions)");
                }
            }
        }
    }
}
