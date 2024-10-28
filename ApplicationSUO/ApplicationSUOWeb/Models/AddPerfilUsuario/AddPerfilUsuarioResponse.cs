using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.AddPerfilUsuario
{
    public class AddPerfilUsuarioResponse
    {
        [JsonPropertyName("filaAgregada")]
        public int FilaAgregada { get; set; }
    }
}
