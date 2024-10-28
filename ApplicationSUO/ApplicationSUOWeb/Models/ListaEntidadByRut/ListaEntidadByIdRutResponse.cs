using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.ListaEntidadByRut
{
    public class ListaEntidadByIdRutResponse
    {
        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccionEntidad")]
        public string DireccionEntidad { get; set; }

        [JsonPropertyName("idRegion")]
        public int IdRegion { get; set; }

        [JsonPropertyName("regionEntidad")]
        public string RegionEntidad { get; set; }

        [JsonPropertyName("idComuna")]
        public int IdComuna { get; set; }

        [JsonPropertyName("comunaEntidad")]
        public string ComunaEntidad { get; set; }

        [JsonPropertyName("contactoEntidad")]
        public string ContactoEntidad { get; set; }

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad { get; set; }

        [JsonPropertyName("imgEntidad1")]
        public string ImgEntidad1 { get; set; }

        [JsonPropertyName("imgEntidad2")]
        public string ImgEntidad2 { get; set; }

        [JsonPropertyName("imgEntidad3")]
        public string ImgEntidad3 { get; set; }

        [JsonPropertyName("fechaModificacion")]
        public string FechaModificacion { get; set; }
    }
}
