using OAuth_Implementation.Models;
using Microsoft.EntityFrameworkCore;
using OAuth_Implementation.Persistence;

namespace OAuth_Implementation.DAL
{
    public static class ScopesDAL
    {
        public static async Task<IEnumerable<string>> ListScopes(DbSet<Scope> scopes)
        {
            return await scopes.Select(scope => scope.Name).ToListAsync();
        }

        public static bool ContainsScope(DbSet<Scope> scopes, string name)
        {
            return scopes.Where(scope => scope.Name == name).Any();
        }
        public static async Task<Tuple<bool, Scope>> AddScope(ApiDbContext context, string scopeName)
        {
            Scope scope = new Scope { Name = scopeName };
            await context.Scopes.AddAsync(scope);
            await context.SaveChangesAsync();
            return new Tuple<bool, Scope>(true, scope);
        }

        public static async Task<Scope?> GetScope(DbSet<Scope> scopes, string scopeName)
        {
            return await scopes.FirstOrDefaultAsync(s => s.Name == scopeName);
        }
        public static async Task<bool> RemoveScope(ApiDbContext context, string scopeName)
        {
            try
            {
                Scope? scope = await context.Scopes.FirstOrDefaultAsync(scope => scope.Name == scopeName);
                if (scope is null)
                    return false;
                context.Scopes.Remove(scope);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
