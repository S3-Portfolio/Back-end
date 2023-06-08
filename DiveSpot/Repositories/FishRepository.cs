using DiveSpot.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiveSpot.Repositories
{
    public class FishRepository
    {
        private readonly DBcontext _context;
        public FishRepository()
        {
            _context = new DBcontext();
        }

        /*public List<Fish> GetAllFish()
        {
            return _context.Fish.ToList();
        }*/

        public virtual List<Fish> GetAllFish()
        {
            return _context.Fish.ToList();
        }

        public List<Fish> GetFishPerWater(int waterId)
        {
            Water? water = _context.Water.Include(water => water.fish).SingleOrDefault(water => water.Id == waterId);
            if (water == null) return new List<Fish>();
            List<Fish> fish = water.fish;

            return fish;
        }

        public virtual Fish GetFish(int Id)
        {
            return _context.Fish.FirstOrDefault(f => f.Id.Equals(Id));
        }

        public void AddFish(Fish fish)
        {
            _context.Fish.Add(fish);
            _context.SaveChanges();
        }

        public void UpdateFish(Fish fish)
        {
            _context.Fish.Update(fish);
            _context.SaveChanges();
        }

        public void DeleteFish(int id)
        {
            var f = new Fish()
            {
                Id = id,
            };
            _context.Fish.Remove(f);
            _context.SaveChanges();
        }
    }
}
