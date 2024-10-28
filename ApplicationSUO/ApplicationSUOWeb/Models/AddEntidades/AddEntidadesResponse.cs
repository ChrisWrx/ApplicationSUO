using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.AddEntidades
{
    public class AddEntidadesResponse
    {
        [JsonPropertyName("filaAgregada")]
        public int FilaAgregada { get; set; }
    }
}
