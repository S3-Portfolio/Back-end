using DiveSpot.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiveSpot.Repositories
{
    public class WaterRepository
    {
        private readonly DBcontext _context;
        public WaterRepository(DBcontext context)
        {
            _context = context;
        }

        public List<Water> GetAllWater()
        {
            return _context.Water.Include(water => water.fish).Include(water => water.dives).ToList();
        }

        public Water GetWater(int Id)
        {
            return _context.Water.Include(water => water.fish).Include(water => water.dives).FirstOrDefault(w => w.Id.Equals(Id));
        }

        public void AddWater(Water water)
        {
            _context.Water.Add(water);
            _context.SaveChanges();
        }

        public void UpdateWater(Water water)
        {
            _context.Water.Update(water);
            _context.SaveChanges();
        }

        public void DeleteWater(int id)
        {
            var w = new Water() { Id = id, };

            _context.Water.Remove(w);
            _context.SaveChanges();
        }
    }
}
