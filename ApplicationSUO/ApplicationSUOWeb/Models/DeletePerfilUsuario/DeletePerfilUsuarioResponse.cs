using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.DeletePerfilUsuario
{
    public class DeletePerfilUsuarioResponse
    {
        [JsonPropertyName("filaEliminada")]
        public int FilaEliminada { get; set; }
    }
}
