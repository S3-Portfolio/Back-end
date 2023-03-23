namespace DiveSpot
{
    public class Water
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Country;
        public readonly List<Dive> dives;

        public Water(int id, string name, string country) 
        { 
            Id = id;
            Name = name;
            Country = country;
        }

        public void AddDiveToList(Dive dive)
        {
            dives.Add(dive);
        }

        public void DeleteDiveFromList(Dive dive)
        {
            dives.Remove(dive);
        }

        public List<Dive> GetList()
        {
            return dives;
        }
    }
}
