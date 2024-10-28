using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.RegionesComunas
{
    public class RegionesComunasResponse
    {
        [JsonPropertyName("idRegion")]
        public int IdRegion { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("idComuna")]
        public int IdComuna { get; set; }

        [JsonPropertyName("comuna")]
        public string Comuna { get; set; }
    }
}
