using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OAuth_Implementation.DAL;
using OAuth_Implementation.Persistence;
using OAuth_Implementation.Models;

namespace OAuth_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopesController : ControllerBase
    {
        ApiDbContext _context;
        public ScopesController(ApiDbContext context)
        {
            _context = context;
        }
        // Test Method
        [HttpGet("echo")]
        public string Get()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet]
        public async Task<IActionResult> ListScopes([FromQuery(Name = "role")] string? role)
        {
            try
            {
                //validate
                if (string.IsNullOrEmpty(role))
                    return Ok(await ScopesDAL.ListScopes(_context.Scopes));
                if (!Guid.TryParse(role, out Guid g))
                    return BadRequest();
                return Ok(await RolesDAL.GetScopesByRole(_context.Roles, g));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromQuery(Name = "name")] string name)
        {
            try
            {
                //validate
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest("name is required");
                if (ScopesDAL.ContainsScope(_context.Scopes, name))
                    return Conflict();

                Tuple<bool, Scope> result = await ScopesDAL.AddScope(_context, name);
                if (!result.Item1) //database error
                    return StatusCode(StatusCodes.Status500InternalServerError);
                string? uri = Url.Link("", null);
                if (string.IsNullOrEmpty(uri))
                {
                    //something weird happened, roll back;
                    _context.Scopes.Remove(result.Item2);
                    await _context.SaveChangesAsync();
                    return BadRequest();
                }
                return Created(new Uri(uri), result.Item2);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery(Name = "name")] string name)
        {
            try
            {
                Scope? scope = await ScopesDAL.GetScope(_context.Scopes, name);
                if (scope is null)
                    return NotFound();
                if (RolesDAL.ScopeInUseByAnyRole(_context.Roles, scope))
                    return Conflict("Scope is currently in use");
                if (!await ScopesDAL.RemoveScope(_context, name))
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
