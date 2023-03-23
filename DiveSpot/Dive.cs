namespace DiveSpot
{
    public class Dive
    {
        public readonly int Id;
        public readonly int WaterId;
        public readonly string Name;
        public readonly int Depth;
        public readonly int Duration;
        public readonly string Qualifications;

        public Dive(int id, int waterid, string name, int depth, int duration, string qualifications)
        {
            Id = id;
            WaterId = waterid;
            Name = name;
            Depth = depth;
            Duration = duration;
            Qualifications = qualifications;
        }
    }
}
