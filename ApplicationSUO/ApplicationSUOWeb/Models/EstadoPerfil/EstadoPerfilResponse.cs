using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.EstadoPerfil
{
    public class EstadoPerfilResponse
    {
        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("descripcionEstado")]
        public string DescripcionEstado { get; set; }
    }
}
