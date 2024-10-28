using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.ListaPerfilUsuario
{
    public class GetListaPerfilUsuarioResponse
    {
        public GetListaPerfilUsuarioResponse(int idLogin, string rutUsuario, string nombreUsuario, string correoUsuario, string rutEntidad, string nombreEntidad, string estado, string perfil, string fechaRegistro)
        {
            IdLogin = idLogin;
            RutUsuario = rutUsuario;
            NombreUsuario = nombreUsuario;
            CorreoUsuario = correoUsuario;
            RutEntidad = rutEntidad;
            NombreEntidad = nombreEntidad;
            Estado = estado;
            Perfil = perfil;
            FechaRegistro = fechaRegistro;
        }
        [JsonPropertyName("idLogin")]
        public int IdLogin { get; set; }

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
