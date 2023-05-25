using DiveSpot.Entities;

namespace DiveSpot.Repositories
{
    public class DiveRepository
    {
        private readonly DBcontext _context;
        public DiveRepository(DBcontext context)
        {
            _context = context;
        }

        public List<Dive> GetAllDive()
        {
            return _context.Dive.ToList();
        }

        private List<Dive> GetDiveListPerWater(int waterId)
        {
            return _context.Dive.Where(d => d.WaterId == waterId).ToList();
        }

        public Dive GetDive(int Id)
        {
            return _context.Dive.FirstOrDefault(d => d.Id.Equals(Id));
        }

        public void AddDive(Dive dive)
        {
            _context.Dive.Add(dive);
            _context.SaveChanges();
        }

        public void UpdateDive(Dive dive)
        {
            _context.Dive.Update(dive);
            _context.SaveChanges();
        }

        public void DeleteDive(int id)
        {
            var d = new Dive() { Id = id, };

            _context.Dive.Remove(d);
            _context.SaveChanges();
        }
    }
}
