using System;
using System.Data.SqlClient;

namespace P04_AddMinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] MinionData = Console.ReadLine().Split();
            string minionName = MinionData[1];
            int age = int.Parse(MinionData[2]);
            string townName = MinionData[3];

            string[] VillainData = Console.ReadLine().Split();
            string villainName = VillainData[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                //----------------- TOWN -----------------
                int? townId = GetTownByName(townName, connection);
                if (townId == null)
                {
                    AddTown(connection, townName);
                }
                townId = GetTownByName(townName, connection);
                              
                //---------------- VILLAIN ---------------
                int? villainId = GetVillainByName(connection, villainName);
                if(villainId == null)
                {
                    AddVillain(connection, villainName);
                }
                villainId = GetVillainByName(connection, villainName);

                //---------------- MINION ----------------
                int? minionId = GetMinionByName(connection, minionName);
                if (minionId == null)
                {
                    AddMinion(connection, minionName, age, townId);
                }
                minionId = GetMinionByName(connection, minionName);

                //----------- MAPPING TABLE --------------
                AddMinionsVillains(connection, villainId, minionId, villainName, minionName);
            }
        }

        private static void AddMinionsVillains(SqlConnection connection, int? villainId, int? minionId, string villainName, string minionName)
        {
            string insertMinionsVillainsSql = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            using (SqlCommand command = new SqlCommand(insertMinionsVillainsSql, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void AddMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string insertMinionSql = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using (SqlCommand command = new SqlCommand(insertMinionSql, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);
                command.ExecuteNonQuery();
            }
        }

        private static int? GetMinionByName(SqlConnection connection, string minionName)
        {
            string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(minionIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertVillainSql = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            using (SqlCommand command = new SqlCommand(insertVillainSql, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static int? GetVillainByName(SqlConnection connection, string villainName)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(villainIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string townName)
        {
            string insertTownSql = "INSERT INTO Towns (Name) VALUES (@townName)";
            using (SqlCommand command = new SqlCommand(insertTownSql, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Town {townName} was added to the database.");
        }

        private static int? GetTownByName(string townName, SqlConnection connection)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using (SqlCommand command = new SqlCommand(townIdQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                return (int?)command.ExecuteScalar();
            }
        }
    }
}
