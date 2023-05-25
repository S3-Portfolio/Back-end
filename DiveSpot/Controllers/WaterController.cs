using DiveSpot.Entities;
using DiveSpot.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiveSpot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        private readonly DBcontext _context;
        private readonly WaterRepository dataBase;

        public WaterController(DBcontext context)
        {
            _context = context;
            dataBase = new WaterRepository(context);
        }

        // GET: api/<WaterController>
        [HttpGet]
        public List<Water> Get()
        {
            return dataBase.GetAllWater();
        }

        // GET api/<WaterController>/5
        [HttpGet("{id}")]
        public Water Get(int id)
        {
            return dataBase.GetWater(id);
        }

        // POST api/<WaterController>
        [HttpPost]
        public void Post(Water water)
        {
            dataBase.AddWater(water);
        }

        // PUT api/<WaterController>
        [HttpPut]
        public void Put(Water water)
        {
            dataBase.UpdateWater(water);
        }

        // DELETE api/<WaterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataBase.DeleteWater(id);
        }
    }
}
