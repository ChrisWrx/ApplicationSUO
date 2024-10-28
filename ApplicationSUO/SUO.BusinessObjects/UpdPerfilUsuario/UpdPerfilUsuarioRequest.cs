using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.UpdPerfilUsuario
{
    public class UpdPerfilUsuarioRequest
    {
        public UpdPerfilUsuarioRequest(int idLogin, string rutUsuario, string correoUsuario, int idEntidad, string rutEntidad, int idPerfil, int idEstado)
        {
            IdLogin = idLogin;
            RutUsuario = rutUsuario;
            CorreoUsuario = correoUsuario;
            IdEntidad = idEntidad;
            RutEntidad = rutEntidad;            
            IdPerfil = idPerfil;
            IdEstado = idEstado;
        }

        [JsonPropertyName("idLogin")]
        public int IdLogin { get; set; }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }

        [JsonPropertyName("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }       

        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }

        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }
    }
}
