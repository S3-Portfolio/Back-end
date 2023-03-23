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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
