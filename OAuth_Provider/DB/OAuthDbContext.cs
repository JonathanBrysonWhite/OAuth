using Microsoft.EntityFrameworkCore;
using OAuth_Provider.Models.DB;

namespace OAuth_Provider.DB
{
    public class OAuthDbContext : DbContext
    {
        public OAuthDbContext(DbContextOptions<OAuthDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Scope> Scopes { get; set; }
    }
}
