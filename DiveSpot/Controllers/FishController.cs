using DiveSpot.Entities;
using DiveSpot.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiveSpot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly DBcontext _context;
        private readonly FishRepository dataBase;

        public FishController(DBcontext context)
        {
            _context = context;
            dataBase = new FishRepository(context);
        }

        // GET: api/<FishController>
        [HttpGet]
        public List<Fish> Get()
        {
            return dataBase.GetAllFish();
        }

        // GET api/<FishController>
        [HttpGet]
        [Route("Fish/Water/{Waterid}")]
        public List<Fish> GetFishPerWater(int waterid)
        {
            return dataBase.GetFishPerWater(waterid);
        }

        // GET api/<FishController>/5
        [HttpGet("{id}")]
        public Fish Get(int id)
        {
            return dataBase.GetFish(id);
        }

        // POST api/<FishController>
        [HttpPost]
        public void Post(Fish fish)
        {
            dataBase.AddFish(fish);
        }

        // PUT api/<FishController>
        [HttpPut]
        public void Put(Fish fish)
        {
            dataBase.UpdateFish(fish);
        }

        // DELETE api/<FishController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataBase.DeleteFish(id);
        }
    }
}
