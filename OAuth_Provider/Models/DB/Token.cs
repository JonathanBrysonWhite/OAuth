namespace OAuth_Provider.Models.DB
{
    public class Token
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public int ClientId { get; set; }
    }
}
