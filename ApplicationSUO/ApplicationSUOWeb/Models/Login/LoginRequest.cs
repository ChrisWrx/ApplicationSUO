using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.Login
{
    public class LoginRequest
    {
        [JsonPropertyName("usuario")]
        public string Usuario { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }              

    }
}
