using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.ListaEntidades
{
    public class ListaEntidadesResponse
    {
        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccionEntidad")]
        public string DireccionEntidad { get; set; }

        [JsonPropertyName("comunaEntidad")]
        public string ComunaEntidad { get; set; }

        [JsonPropertyName("regionEntidad")]
        public string RegionEntidad { get; set; }

        [JsonPropertyName("contactoEntidad")]
        public string ContactoEntidad { get; set; }

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad { get; set; }
    }
}
