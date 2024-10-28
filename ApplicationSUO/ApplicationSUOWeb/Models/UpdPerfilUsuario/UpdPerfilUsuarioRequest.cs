using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.UpdPerfilUsuario
{
    public class UpdPerfilUsuarioRequest
    {
        [JsonPropertyName("idLogin")]
        public int IdLogin { get; set; }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }

        [JsonPropertyName("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }      

        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }

        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }
    }
}
