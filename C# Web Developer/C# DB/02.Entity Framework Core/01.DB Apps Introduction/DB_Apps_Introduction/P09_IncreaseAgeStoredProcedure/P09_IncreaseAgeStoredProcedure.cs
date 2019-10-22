namespace P09_IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;

    class P09_IncreaseAgeStoredProcedure
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();

                int id = int.Parse(Console.ReadLine());
                SqlCommand command = new SqlCommand("EXEC usp_GetOlder @Id", dbCon);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
                    }
                }
            }
        }
    }
}
