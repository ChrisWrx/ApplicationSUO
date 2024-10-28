using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.Pacientes
{
    public class PacienteResponse
    {
        [JsonPropertyName("idAtenciones")]
        public int IdAtenciones { get; set; }

        [JsonPropertyName("rut")]
        public string Rut { get; set; }

        [JsonPropertyName("nombrePaciente")]
        public string NombrePaciente { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}

