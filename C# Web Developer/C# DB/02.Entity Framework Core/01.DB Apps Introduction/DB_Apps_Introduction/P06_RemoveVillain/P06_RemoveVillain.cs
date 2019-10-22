namespace P06_RemoveVillain
{
    using System;
    using System.Data.SqlClient;

    class P06_RemoveVillain
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();

                int villainId = int.Parse(Console.ReadLine());
                SqlCommand command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", dbCon);
                command.Parameters.AddWithValue("@villainId", villainId);

                string villainName = (string)command.ExecuteScalar();
                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                command = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId", dbCon);
                command.Parameters.AddWithValue("@villainId", villainId);
                int releasedMinions = command.ExecuteNonQuery();

                command = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", dbCon);
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
                
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }
    }
}
