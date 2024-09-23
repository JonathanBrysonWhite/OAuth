using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OAuth_Provider.DB;
using OAuth_Provider.Models.DB;
using OAuth_Provider.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OAuth_Provider.Controllers
{
    [ApiController]
    [Route("connect")]
    public class TokenController : ControllerBase
    {
        private readonly OAuthDbContext _context;

        public TokenController(OAuthDbContext context)
        {
            _context = context;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token([FromForm] TokenRequest request)
        {
            return await _Token(request);
        }



        #region AUXILIARY_METHODS
        protected async Task<IActionResult> _Token(TokenRequest request)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == request.ClientId);

            if (client == null || !VerifyClientSecret(client.ClientSecret, request.ClientSecret))
            {
                return Unauthorized();
            }

            var scopes = request.Scope.Split(' ').ToList();
            if (AreScopesValid(scopes, client.AllowedScopes.Split(',').ToList()))
            {
                return BadRequest("Invalid scope.");
            }
            var token = GenerateToken(client, scopes);
            return Ok(new { access_token = token, token_type = "Bearer" });
        }
        #endregion

        #region PRIVATE_METHODS
        private bool VerifyClientSecret(string storedSecret, string providedSecret)
        {
            return storedSecret == providedSecret; //TODO REPLACE WITH HASHED COMPARISON
        }
        private bool AreScopesValid(List<string> requestedScopes, List<string> allowedScopes)
        {
            return requestedScopes.All(scope => allowedScopes.Contains(scope));
        }
        private string GenerateToken(Client client, List<string> scopes)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, client.ClientId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Concat(scopes.Select(scope => new Claim("scope", scope)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TODO GET SECRET KEY FROM SECRET STORE"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "todo configure issuer",
                audience: "todo configure audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60), // todo configure this
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
