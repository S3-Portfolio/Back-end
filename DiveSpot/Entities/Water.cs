using System.ComponentModel.DataAnnotations;

namespace DiveSpot.Entities
{
    public class Water
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }

        public List<Dive>? dives { get; set; }
        public List<Fish> fish { get; set; } = new List<Fish>();
    }
}
