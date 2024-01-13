namespace OAuth_Implementation.Models
{
    public class Role : Base
    {
        public Role()
        {
            Scopes = new HashSet<Scope>();
        }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Scope> Scopes { get; set; }
    }
}
