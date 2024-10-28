using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.GeneraPDF
{
    public class GeneraPDFResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rutPaciente")]
        public string RutPaciente { get; set; }

        [JsonPropertyName("nombresPaciente")]
        public string NombresPaciente { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("direccionPaciente")]
        public string DireccionPaciente { get; set; }

        [JsonPropertyName("comunaPaciente")]
        public string ComunaPaciente { get; set; }

        [JsonPropertyName("regionPaciente")]
        public string RegionPaciente { get; set; }

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

        [JsonPropertyName("horaAtencion")]
        public string HoraAtencion { get; set; }

        [JsonPropertyName("fechaAtencion")]
        public string FechaAtencion { get; set; }

        [JsonPropertyName("fechaAlta")]
        public string FechaAlta { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("diagnostico")]
        public string Diagnostico { get; set; }
    }
}

