using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.ListaPerfilUsuarioByIdRutResponse
{
    public class ListaPerfilUsuarioByIdRutResponse
    {
        [JsonPropertyName("idLogin")]
        public int IdLogin { get; set; }

        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("descripcionEstado")]
        public string DescripcionEstado { get; set; }

        [JsonPropertyName("descripcionPerfil")]
        public string DescripcionPerfil { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public string FechaRegistro { get; set; }

        [JsonPropertyName("fechaModificacion")]
        public string FechaModificacion { get; set; }
    }
}
