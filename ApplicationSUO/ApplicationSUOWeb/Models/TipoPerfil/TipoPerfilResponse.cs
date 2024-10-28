using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.TipoPerfil
{
    public class TipoPerfilResponse
    {
        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }

        [JsonPropertyName("descripcionPerfil")]
        public string DescripcionPerfil { get; set; }
    }
}
