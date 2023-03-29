using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiveSpot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiveController : ControllerBase
    {
        DataBase dataBase = new DataBase();
        
        // GET: api/<DiveController>
        [HttpGet]
        public List<Dive> Get()
        {
            return dataBase.GetAllDive();
        }

        // GET api/<DiveController>/5
        [HttpGet("{id}")]
        public Dive Get(int id)
        {
            return dataBase.GetDive(id);
        }

        // POST api/<DiveController>
        [HttpPost]
        public void Post(Dive dive)
        {
            dataBase.AddDive(dive);
        }

        // PUT api/<DiveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
