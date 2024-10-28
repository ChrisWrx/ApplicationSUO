using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.AddPerfilUsuario
{
    public class AddPerfilUsuarioRequest
    {
        public AddPerfilUsuarioRequest() 
        {
        
        }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }       

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }

        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }       
    }
}
