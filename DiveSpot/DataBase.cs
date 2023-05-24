using System.Data;
using System.Data.SqlClient;

namespace DiveSpot
{
    public class DataBase
    {
        private readonly DBcontext _context;
        public DataBase(DBcontext context)
        {
            _context = context;
        }


        // Fish
        public List<Fish> GetAllFish()
        {
            List<Fish> fish = _context.Fish.ToList();

            return fish;
        }

        public List<Fish> GetFishPerWater(int waterId)
        {
            var result = _context.Fish
             .Join(_context.Fish_Water,
                   f => f.Id,
                   fw => fw.FishID,
                   (f, fw) => new { Fish = f, FishWater = fw })
             .Join(_context.Water,
                   fw => fw.FishWater.WaterID,
                   w => w.Id,
                   (fw, w) => new { Fish = fw.Fish, Water = w })
             .Where(fw => fw.Water.Id == waterId)
             .Select(fw => fw.Fish)
             .ToList();

            List<Fish> fish = result;

            return fish;
        }

        public Fish GetFish(int Id)
        {
            return _context.Fish.FirstOrDefault(f => f.Id.Equals(Id));
        }

        public void AddFish(Fish fish)
        {
            _context.Fish.Add(fish);
            _context.SaveChanges();
        }

        public void UpdateFish(Fish fish)
        {
            _context.Fish.Update(fish);
            _context.SaveChanges();
        }

        public void DeleteFish(int id) 
        {
            var f = new Fish()
            {
                Id = id,
            };
            _context.Fish.Remove(f);
            _context.SaveChanges();
        }

        // Dive
        public List<Dive> GetAllDive()
        {
            List<Dive> dives = _context.Dive.ToList();

            foreach (Dive dive in dives)
            {
                List<Fish> f = GetFishPerWater(dive.WaterId);
                if (f != null)
                {
                    dive.Fish = f;
                }
            }

            return dives;
        }

        private List<Dive> GetDiveListPerWater(int waterId) 
        {
            List<Dive> dives = _context.Dive.Where(d => d.WaterId == waterId).ToList();

            foreach (Dive dive in dives)
            {
                List<Fish> f = GetFishPerWater(dive.WaterId);
                if (f != null)
                {
                    dive.Fish = f;
                }
            }

            return dives;
        }

        public Dive GetDive(int Id)
        {
            Dive d = _context.Dive.FirstOrDefault(d => d.Id.Equals(Id));

            List<Fish> f = GetFishPerWater(d.WaterId);
            if (f != null)
            {
                d.Fish = f;
            }

            return d;
        }

        public void AddDive(Dive dive)
        {
            /*string queryString = "INSERT INTO dbo.Dive (ID, WaterID, Name, Depth, Duration, Qualifications) VALUES (@ID, @WaterID, @Name, @Depth, @Duration, @Qualifications);";

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
            }*/

            _context.Dive.Add(dive);
            _context.SaveChanges();
        }

        public void UpdateDive(Dive dive)
        {
            /*string queryString = "INSERT INTO dbo.Dive (ID, WaterID, Name, Depth, Duration, Qualifications) VALUES (@ID, @WaterID, @Name, @Depth, @Duration, @Qualifications) WHERE ID = @ID;";

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
            }*/

            _context.Dive.Update(dive);
            _context.SaveChanges();
        }

        public void DeleteDive(int id)
        {
            /*string queryString = "DELETE FROM dbo.Dive WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }*/

            var d = new Dive() { Id = id, };

            d.Fish.Clear();

            _context.Dive.Remove(d);
            _context.SaveChanges();
        }

        // Water
        public List<Water> GetAllWater()
        {
            /*string queryString = "SELECT ID, Name, Country FROM dbo.Water";

            DataTable data = DBQuery(new SqlCommand(queryString));

            List<Water> list = new List<Water>();

            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                string name = Convert.ToString(row["Name"]);
                string country = Convert.ToString(row["Country"]);

                Water water = new Water(id, name, country);
                if(GetDiveListPerWater(water.Id) != null)
                {
                    foreach (Dive dive in GetDiveListPerWater(water.Id))
                    {
                        water.AddDiveToList(dive);
                    }
                }

                list.Add(water);
            }

            return list;*/

            List<Water> water = _context.Water.ToList();

            return water;
        }

        public Water GetWater(int Id)
        {
            /*string queryString = "SELECT ID, Name, Country FROM dbo.Water WHERE ID = @ID";

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

            return water;*/

            return _context.Water.FirstOrDefault(w => w.Id.Equals(Id));
        }

        public void AddWater(Water water)
        {
            /*string queryString = "INSERT INTO dbo.Water (ID, Name, Country) VALUES (@ID, @Name, @Country);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", water.Id);
                command.Parameters.AddWithValue("@Name", water.Name);
                command.Parameters.AddWithValue("@Country", water.Country);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }*/

            _context.Water.Add(water);
            _context.SaveChanges();
        }

        public void UpdateWater(Water water)
        {
            /*string queryString = "INSERT INTO dbo.Water (ID, Name, Country) VALUES (@ID, @Name, @Country) WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", water.Id);
                command.Parameters.AddWithValue("@Name", water.Name);
                command.Parameters.AddWithValue("@Country", water.Country);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }*/

            _context.Water.Update(water);
            _context.SaveChanges();
        }

        public void DeleteWater(int id)
        {
            /*string queryString = "DELETE FROM dbo.Water WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }*/

            var w = new Water() { Id = id, };
            _context.Water.Remove(w);
            _context.SaveChanges();
        }
    }
}
