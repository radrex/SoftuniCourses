namespace P05_ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class P05_ChangeTownNamesCasing
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();

                string country = Console.ReadLine();
                SqlCommand command = new SqlCommand("SELECT t.Name " +
                                                    "FROM Towns as t " +
                                                    "JOIN Countries AS c ON c.Id = t.CountryCode " +
                                                    "WHERE c.Name = @countryName", dbCon);
                command.Parameters.AddWithValue("@countryName", country);

                List<string> towns = new List<string>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string town = (string)reader["Name"];
                        towns.Add(town.ToUpper());
                    }
                }

                if (towns.Count != 0)
                {
                    command = new SqlCommand("UPDATE Towns " +
                                             "SET Name = UPPER(Name) " +
                                             "WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", dbCon);
                    command.Parameters.AddWithValue("@countryName", country);
                    int updatedRows = command.ExecuteNonQuery();

                    Console.WriteLine($"{updatedRows} town names were affected.");
                    Console.WriteLine($"[{String.Join(", ", towns)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
