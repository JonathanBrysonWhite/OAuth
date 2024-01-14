using OAuth_Implementation.Models;
using Microsoft.EntityFrameworkCore;
using OAuth_Implementation.Persistence;

namespace OAuth_Implementation.DAL
{
    public static class ScopesDAL
    {
        public static async Task<IEnumerable<string>> ListScopes(DbSet<Scope> scopes)
        {
            try
            {
                return await scopes.Select(scope => scope.Name).ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<string>();
            }
        }

        public static bool ContainsScope(DbSet<Scope> scopes, string name)
        {
            return scopes.Where(scope => scope.Name == name).Any();
        }
        public static async Task<Tuple<bool, Scope>> AddScope(ApiDbContext context, string scopeName)
        {
            try
            {
                Scope scope = new Scope { Name = scopeName };
                await context.Scopes.AddAsync(scope);
                await context.SaveChangesAsync();
                return new Tuple<bool, Scope>(true, scope);
            }
            catch
            {
                await context.DisposeAsync();
                return new Tuple<bool, Scope>(false, new Scope());
            }
        }
    }
}
