namespace DiveSpot.Entities
{
    public class Dive
    {
        public int Id { get; set; }
        public int WaterId { get; set; }
        //public Water water { get; set; }
        public string Name { get; set; }
        public int Depth { get; set; }
        public int Duration { get; set; }
        public string Qualifications { get; set; }
    }
}
