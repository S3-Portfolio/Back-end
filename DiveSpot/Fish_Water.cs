using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiveSpot
{
    public class Fish_Water
    {
        public int Id { get; set; }
        public int FishID { get; set; }
        public int WaterID { get; set; }

        public Fish Fish { get; set; }
        public Water Water { get; set; }
    }
}
