namespace P08_IncreaseMinionAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class P08_IncreaseMinionAge
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();
                int[] minionsIDs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                foreach (int id in minionsIDs)
                {
                    SqlCommand updateCommand = new SqlCommand("UPDATE Minions " +
                                                              "SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 " +
                                                              "WHERE Id = @Id", dbCon);
                    updateCommand.Parameters.AddWithValue("@Id", id);
                    updateCommand.ExecuteNonQuery();
                }


                SqlCommand selectCommand = new SqlCommand("SELECT Name, Age FROM Minions", dbCon);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
