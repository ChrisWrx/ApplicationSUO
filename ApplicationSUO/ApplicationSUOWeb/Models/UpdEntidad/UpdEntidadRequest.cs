using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.UpdEntidad
{
    public class UpdEntidadRequest
    {
        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad { get; set; }

        [JsonPropertyName("contactoEntidad")]
        public string ContactoEntidad { get; set; }

        [JsonPropertyName("imgEntidad1")]
        public string ImgEntidad1 { get; set; }

        [JsonPropertyName("imgEntidad2")]
        public string ImgEntidad2 { get; set; }

        [JsonPropertyName("imgEntidad3")]
        public string ImgEntidad3 { get; set; }
    }
}
