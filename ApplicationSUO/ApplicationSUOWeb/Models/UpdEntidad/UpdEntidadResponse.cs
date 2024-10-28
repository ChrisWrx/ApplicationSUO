using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.UpdEntidad
{
    public class UpdEntidadResponse
    {
        [JsonPropertyName("filaModificada")]
        public int FilaModificada { get; set; }
    }
}
