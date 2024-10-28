using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.ListaImgCarrusel
{
    public class ListaImgCarruselResponse
    {
        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("imgEntidad1")]
        public string ImgEntidad1 { get; set; }

        [JsonPropertyName("imgEntidad2")]
        public string ImgEntidad2 { get; set; }

        [JsonPropertyName("imgEntidad3")]
        public string ImgEntidad3 { get; set; }
    }
}
