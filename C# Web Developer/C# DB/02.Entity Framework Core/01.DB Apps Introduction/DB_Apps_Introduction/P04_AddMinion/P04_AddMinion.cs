namespace P04_AddMinion
{
    using System;
    using System.Data.SqlClient;

    class P04_AddMinion
    {
        static void Main(string[] args)
        {
            using (SqlConnection dbCon = new SqlConnection(@"Server=.;Database=MinionsDB;Integrated Security=true"))
            {
                dbCon.Open();
                string[] minionData = Console.ReadLine().Split();
                string minionName = minionData[1];
                int minionAge = int.Parse(minionData[2]);
                string town = minionData[3];

                //--------------------------------- CHECK TOWN ---------------------------------
                SqlCommand selectCommand = new SqlCommand($"SELECT Id FROM Towns WHERE Name = @townName", dbCon);
                selectCommand.Parameters.AddWithValue("@townName", town);
                int? townId = (int?)selectCommand.ExecuteScalar();

                if (townId == null)
                {
                    SqlCommand insertCommand = new SqlCommand($"INSERT INTO Towns (Name) VALUES (@townName)", dbCon);
                    insertCommand.Parameters.AddWithValue("@townName", town);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine($"Town {town} was added to the database.");
                    townId = (int)selectCommand.ExecuteScalar();
                }

                //------------------------------- CHECK VILLAIN --------------------------------
                string[] villainData = Console.ReadLine().Split();
                string villainName = villainData[1];

                selectCommand = new SqlCommand($"SELECT Id FROM Villains WHERE Name = @Name", dbCon);
                selectCommand.Parameters.AddWithValue("@Name", villainName);
                int? villainId = (int?)selectCommand.ExecuteScalar();

                if (villainId == null)
                {
                    SqlCommand insertCommand = new SqlCommand($"INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@villainName, 4)", dbCon);
                    insertCommand.Parameters.AddWithValue("@villainName", villainName);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                    villainId = (int)selectCommand.ExecuteScalar();
                }
                
                //-------------------------------- CHECK MINION --------------------------------
                selectCommand = new SqlCommand($"SELECT Id FROM Minions WHERE Name = @Name", dbCon);
                selectCommand.Parameters.AddWithValue("@Name", minionName);
                int? minionId = (int?)selectCommand.ExecuteScalar();

                if (minionId == null)
                {
                    SqlCommand insertCommand = new SqlCommand($"INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)", dbCon);
                    insertCommand.Parameters.AddWithValue("@name", minionName);
                    insertCommand.Parameters.AddWithValue("@age", minionAge);
                    insertCommand.Parameters.AddWithValue("@townId", townId);
                    insertCommand.ExecuteNonQuery();
                    minionId = (int)selectCommand.ExecuteScalar();

                    SqlCommand mappingInsertCommand = new SqlCommand($"INSERT INTO MinionsVillains (VillainId, MinionId) VALUES (@villainId, @minionId)", dbCon);
                    mappingInsertCommand.Parameters.AddWithValue("@villainId", villainId);
                    mappingInsertCommand.Parameters.AddWithValue("@minionId", minionId);
                    mappingInsertCommand.ExecuteNonQuery();
                }

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
