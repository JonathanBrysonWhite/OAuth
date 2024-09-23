namespace OAuth_Provider.Models.DB
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AllowedScopes { get; set; } // comma seperated
    }
}
