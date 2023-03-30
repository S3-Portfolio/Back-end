namespace DiveSpot
{
    public class Water
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public List<Dive>? dives { get; set; }

        /*public Water(*//*int id, string name, string country*//*) 
        { 
            *//*Id = id;
            Name = name;
            Country = country;*//*
        }*/

        /*public void AddDiveToList(Dive dive)
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
        }*/
    }
}
