using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OAuth_Provider.Models.Request
{
    public class TokenRequest
    {
        [Required]
        [FromForm(Name = "grant_type")]
        public string GrantType { get; set; }

        [Required]
        [FromForm(Name = "client_id")]
        public string ClientId { get; set; }

        [Required]
        [FromForm(Name = "client_secret")]
        public string ClientSecret { get; set; }

        [FromForm(Name = "scope")]
        public string Scope { get; set; }
    }
}
