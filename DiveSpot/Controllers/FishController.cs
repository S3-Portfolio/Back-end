using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiveSpot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        DataBase dataBase = new DataBase();

        // GET: api/<FishController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FishController>/5
        [HttpGet("{id}")]
        public Fish Get(int id)
        {
            return dataBase.GetFish(id);
        }

        // POST api/<FishController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FishController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FishController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
