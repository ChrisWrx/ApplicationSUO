using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.AddPerfilUsuario
{
    public class AddPerfilUsuarioRequest
    {
        public AddPerfilUsuarioRequest(string rutUsuario, string nombreUsuario, string apellidoPaterno, string apellidoMaterno, string correoUsuario, int idEntidad, string rutEntidad, string password, int idPerfil, int idEstado)
        {
            RutUsuario = rutUsuario;
            NombreUsuario = nombreUsuario;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            CorreoUsuario = correoUsuario;
            IdEntidad = idEntidad;
            RutEntidad = rutEntidad;           
            Password = password;
            IdPerfil = idPerfil;
            IdEstado = idEstado;           
        }

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

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }

        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }    

    }
}
