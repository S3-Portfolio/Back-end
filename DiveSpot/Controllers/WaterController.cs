using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiveSpot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        DataBase dataBase = new DataBase();

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WaterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WaterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
