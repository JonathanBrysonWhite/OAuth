using OAuth_Implementation.Models;
using Microsoft.EntityFrameworkCore;
namespace OAuth_Implementation.DAL
{
    public static class RolesDAL
    {
        public static async Task<IEnumerable<Role>> ListRoles(DbSet<Role> roles)
        {
            return await roles.ToListAsync();
        }

        public static async Task<Role?> GetRoleById(DbSet<Role> roles, string id)
        {
            return await roles.FindAsync(id);
        }

        public static async Task<IEnumerable<string>> GetScopesByRole(DbSet<Role> roles, Guid id)
        {
            Role? role = await roles.FindAsync(id);
            if (role is null)
                return new List<string>();
            return role.Scopes.Select(x => x.Name).ToList();
        }
    }
}
