using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.DeletePerfilUsuario
{
    public class DeletePerfilUsuarioRequest
    {       
        [JsonPropertyName("idLogin")]
        public int IdLogin { get; set; }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }
    }
}
