namespace OAuth_Implementation.Models
{
    public class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public string AddedBy { get; set; } = string.Empty;
        public int Status { get; set; } = 1;
    }
}
