namespace DiveSpot
{
    public class Fish
    {
        public readonly int Id;
        public readonly string Name;
        public readonly int Depth;
        public readonly string Img;
        public readonly string SName;

        public Fish(int id, string name, string Sname, int depth, string img) 
        {
            Id = id;
            Name = name;
            SName = Sname;
            Depth = depth;
            Img = img;
        }
    }
}
