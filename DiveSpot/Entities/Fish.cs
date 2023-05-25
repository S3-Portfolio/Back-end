using System.ComponentModel.DataAnnotations;

namespace DiveSpot.Entities
{
    public class Fish
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Depth { get; set; }
        public string? Img { get; set; }
        public string? SName { get; set; }

        public List<Water> water { get; } = new();
    }
}
