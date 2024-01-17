using Microsoft.AspNetCore.Mvc;
using OAuth_Implementation.Models;
using OAuth_Implementation.Persistence;
using OAuth_Implementation.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OAuth_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private ApiDbContext _context;
        public RolesController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Role>> List()
        {
            return await RolesDAL.ListRoles(_context.Roles);
        }
        /*
        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RolesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
