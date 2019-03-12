using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05_ChangTownNameCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            List<string> towns = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateTownNames = "UPDATE Towns " +
                                         "SET Name = UPPER(Name) " +
                                         "WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected != 0)
                    {
                        Console.WriteLine($"{rowsAffected} town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"No town names were affected.");
                    }
                }

                string townNamesQuery = "SELECT t.Name " +
                                        "FROM Towns as t " +
                                        "JOIN Countries AS c ON c.Id = t.CountryCode " +
                                        "WHERE c.Name = @countryName";

                using (SqlCommand command = new SqlCommand(townNamesQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }
            }
            Console.WriteLine("[" + String.Join(", ", towns) + "]");   
        }
    }
}
