namespace OAuth_Implementation.Models
{
    public class User : Base
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = new Role();
        public Guid RoleId { get; set; }
    }
}
