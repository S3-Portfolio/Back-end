﻿using System.Data;
using System.Data.SqlClient;

namespace DiveSpot
{
    public class DataBase
    {
        const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DiveSpotDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DataTable DBQuery(SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                DataTable data = new DataTable();
                data.Load(reader);

                return data;
            }
        }

        // Fish
        public List<Fish> GetAllFish()
        {
            string queryString = "SELECT ID, Name, SName, Depth, Img FROM dbo.Fish;";

            DataTable data = DBQuery(new SqlCommand(queryString));

            List<Fish> list = new List<Fish>();

            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                string name = Convert.ToString(row["Name"]);
                string Sname = Convert.ToString(row["SName"]);
                int depth = Convert.ToInt32(row["Depth"]);
                string img = Convert.ToString(row["Img"]);

                Fish fish = new Fish(id, name, Sname, depth, img);

                list.Add(fish);
            }
            return list;
        }

        public Fish GetFish(int Id)
        {
            string queryString = "SELECT ID, Name, SName, Depth, Img FROM dbo.Fish WHERE ID = @fishID;";

            SqlCommand command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@fishID", Id);

            DataTable data = DBQuery(command);
            DataRow row = data.Rows[0];

            int id = Convert.ToInt32(row["ID"]);
            string name = Convert.ToString(row["Name"]);
            string Sname = Convert.ToString(row["SName"]);
            int depth = Convert.ToInt32(row["Depth"]);
            string img = Convert.ToString(row["Img"]);

            Fish fish = new Fish(id, name, Sname, depth, img);

            return fish;
        }

        public void AddFish(Fish fish)
        {
            string queryString = "INSERT INTO dbo.Fish (ID, Name, SName, Depth, Img) VALUES (@ID, @Name, @SName, @Depth, @Img);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", fish.Id);
                command.Parameters.AddWithValue("@Name", fish.Name);
                command.Parameters.AddWithValue("@SName", fish.SName);
                command.Parameters.AddWithValue("@Depth", fish.Depth);
                command.Parameters.AddWithValue("@Img", fish.Img);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateFish(Fish fish)
        {
            string queryString = "INSERT INTO dbo.Fish (ID, Name, SName, Depth, Img) VALUES (@ID, @Name, @SName, @Depth, @Img) WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", fish.Id);
                command.Parameters.AddWithValue("@Name", fish.Name);
                command.Parameters.AddWithValue("@SName", fish.SName);
                command.Parameters.AddWithValue("@Depth", fish.Depth);
                command.Parameters.AddWithValue("@Img", fish.Img);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFish(int id) 
        {
            string queryString = "DELETE FROM dbo.Fish WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Dive
        public List<Dive> GetAllDive()
        {
            string queryString = "SELECT ID, WaterID, Name, Depth, Duration, Qualifications FROM dbo.Dive";

            DataTable data = DBQuery(new SqlCommand(queryString));

            List<Dive> list = new List<Dive>();

            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                int waterid = Convert.ToInt32(row["WaterID"]);
                string name = Convert.ToString(row["Name"]);
                int depth = Convert.ToInt32(row["Depth"]);
                int duration = Convert.ToInt32(row["Duration"]);
                string qualifications = Convert.ToString(row["Qualifications"]);

                Dive dive = new Dive(id, waterid, name, depth, duration, qualifications);

                list.Add(dive);
            }

            return list;
        }

        private List<Dive> GetDiveListPerWater(int waterId) 
        {
            string queryString = "SELECT ID, WaterID, Name, Depth, Duration, Qualifications FROM dbo.Dive WHERE WaterID = @WaterID";

            SqlCommand command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@WaterID", waterId);

            DataTable data = DBQuery(command);

            List<Dive> list = new List<Dive>();

            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                int waterid = Convert.ToInt32(row["WaterID"]);
                string name = Convert.ToString(row["Name"]);
                int depth = Convert.ToInt32(row["Depth"]);
                int duration = Convert.ToInt32(row["Duration"]);
                string qualifications = Convert.ToString(row["Qualifications"]);

                Dive dive = new Dive(id, waterid, name, depth, duration, qualifications);

                list.Add(dive);
            }

            return list;
        }

        public Dive GetDive(int Id)
        {
            string queryString = "SELECT ID, WaterID, Name, Depth, Duration, Qualifications FROM dbo.Dive WHERE ID = @ID";

            SqlCommand command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@ID", Id);

            DataTable data = DBQuery(command);
            DataRow row = data.Rows[0];

            int id = Convert.ToInt32(row["ID"]);
            int waterid = Convert.ToInt32(row["WaterID"]);
            string name = Convert.ToString(row["Name"]);
            int depth = Convert.ToInt32(row["Depth"]);
            int duration = Convert.ToInt32(row["Duration"]);
            string qualifications = Convert.ToString(row["Qualifications"]);

            Dive dive = new Dive(id, waterid, name, depth, duration, qualifications);

            return dive;
        }

        public void AddDive(Dive dive)
        {
            string queryString = "INSERT INTO dbo.Dive (ID, WaterID, Name, Depth, Duration, Qualifications) VALUES (@ID, @WaterID, @Name, @Depth, @Duration, @Qualifications);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", dive.Id);
                command.Parameters.AddWithValue("@WaterID", dive.WaterId);
                command.Parameters.AddWithValue("@Name", dive.Name);
                command.Parameters.AddWithValue("@Depth", dive.Depth);
                command.Parameters.AddWithValue("@Duration", dive.Duration);
                command.Parameters.AddWithValue("@Qualifications", dive.Qualifications);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateDive(Dive dive)
        {
            string queryString = "INSERT INTO dbo.Dive (ID, WaterID, Name, Depth, Duration, Qualifications) VALUES (@ID, @WaterID, @Name, @Depth, @Duration, @Qualifications) WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", dive.Id);
                command.Parameters.AddWithValue("@WaterID", dive.WaterId);
                command.Parameters.AddWithValue("@Name", dive.Name);
                command.Parameters.AddWithValue("@Depth", dive.Depth);
                command.Parameters.AddWithValue("@Duration", dive.Duration);
                command.Parameters.AddWithValue("@Qualifications", dive.Qualifications);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDive(int id)
        {
            string queryString = "DELETE FROM dbo.Dive WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Water
        public List<Water> GetAllWater()
        {
            string queryString = "SELECT ID, Name, Country FROM dbo.Water";

            DataTable data = DBQuery(new SqlCommand(queryString));

            List<Water> list = new List<Water>();

            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                string name = Convert.ToString(row["Name"]);
                string country = Convert.ToString(row["Country"]);

                Water water = new Water(id, name, country);
                foreach (Dive dive in GetDiveListPerWater(water.Id))
                {
                    water.AddDiveToList(dive);
                }

                list.Add(water);
            }

            return list;
        }

        public Water GetWater(int Id)
        {
            string queryString = "SELECT ID, Name, Country FROM dbo.Water WHERE ID = @ID";

            SqlCommand command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@ID", Id);

            DataTable data = DBQuery(command);
            DataRow row = data.Rows[0];

            int id = Convert.ToInt32(row["ID"]);
            string name = Convert.ToString(row["Name"]);
            string country = Convert.ToString(row["Country"]);

            Water water = new Water(id, name, country);
            foreach (Dive dive in GetDiveListPerWater(water.Id))
            {
                water.AddDiveToList(dive);
            }

            return water;
        }

        public void AddWater(Water water)
        {
            string queryString = "INSERT INTO dbo.Water (ID, Name, Country) VALUES (@ID, @Name, @Country);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", water.Id);
                command.Parameters.AddWithValue("@Name", water.Name);
                command.Parameters.AddWithValue("@Country", water.Country);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateWater(Water water)
        {
            string queryString = "INSERT INTO dbo.Water (ID, Name, Country) VALUES (@ID, @Name, @Country) WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", water.Id);
                command.Parameters.AddWithValue("@Name", water.Name);
                command.Parameters.AddWithValue("@Country", water.Country);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteWater(int id)
        {
            string queryString = "DELETE FROM dbo.Water WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}