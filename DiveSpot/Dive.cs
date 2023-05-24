namespace DiveSpot
{
    public class Dive
    {
        public int Id { get; set; }
        public int WaterId { get; set; }
        //public readonly Water water;
        public string? Name { get; set; }
        public int? Depth { get; set; }
        public int? Duration { get; set; }
        public string? Qualifications { get; set; }
        public List<Fish> Fish { get; set; }

        /*public Dive(*//*int id, int waterid, string name, int depth, int duration, string qualifications*//*)
        {
            *//*Id = id;
            WaterId = waterid;
            Name = name;
            Depth = depth;
            Duration = duration;
            Qualifications = qualifications;*//*
        }*/
    }
}
