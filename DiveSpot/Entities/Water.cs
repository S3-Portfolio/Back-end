namespace DiveSpot.Entities
{
    public class Water
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Dive> dives { get; set; }
    }
}
