using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.ListaRutNombreEntidad
{
    public class ListaRutNombreEntidadResponse
    {
        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }        

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }
    }
}
