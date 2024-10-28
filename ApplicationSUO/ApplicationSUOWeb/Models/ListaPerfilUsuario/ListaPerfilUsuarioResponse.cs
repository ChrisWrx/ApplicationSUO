using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.ListaPerfilUsuario
{
    public class ListaPerfilUsuarioResponse
    {
        [JsonPropertyName("idLogin")]
        public string IdLogin { get; set; }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; }

        [JsonPropertyName("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("perfil")]
        public string Perfil { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public string FechaRegistro { get; set; }
    }
}
