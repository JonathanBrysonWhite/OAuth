using Microsoft.EntityFrameworkCore;
using OAuth_Implementation.Models;
namespace OAuth_Implementation.Persistence
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scope> Scopes { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<Scope>().ToTable("scopes");
        }
    }
}
