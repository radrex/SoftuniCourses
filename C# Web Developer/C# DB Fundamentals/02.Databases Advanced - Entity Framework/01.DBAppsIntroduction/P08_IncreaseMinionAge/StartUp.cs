using System;
using System.Data.SqlClient;
using System.Linq;

namespace P08_IncreaseMinionAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string updateMinions = "UPDATE Minions " +
                                       "SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 " +
                                       "WHERE Id = @Id";

                for (int i = 0; i < ids.Length; i++)
                {
                    using (SqlCommand command = new SqlCommand(updateMinions, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ids[i]);
                        command.ExecuteNonQuery();
                    }
                }

                string minionsQuery = "SELECT Name, Age FROM Minions";
                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} {age}");
                        }
                    }
                }
            }
        }
    }
}
