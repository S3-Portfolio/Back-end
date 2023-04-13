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
        private readonly DBcontext _context;
        private readonly DataBase dataBase;

        public DiveController(DBcontext context)
        {
            _context = context;
            dataBase = new DataBase(context);
        }

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

        // PUT api/<DiveController>
        [HttpPut]
        public void Put(Dive dive)
        {
            dataBase.UpdateDive(dive);
        }

        // DELETE api/<DiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataBase.DeleteDive(id);
        }
    }
}
