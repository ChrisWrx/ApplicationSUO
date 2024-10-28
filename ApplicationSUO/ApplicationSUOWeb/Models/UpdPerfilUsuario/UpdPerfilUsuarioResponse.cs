using System.Text.Json.Serialization;

namespace ApplicationSUOWeb.Models.UpdPerfilUsuario
{
    public class UpdPerfilUsuarioResponse
    {
        [JsonPropertyName("filaActualizada")]
        public int FilaActualizada { get; set; }
    }
}
