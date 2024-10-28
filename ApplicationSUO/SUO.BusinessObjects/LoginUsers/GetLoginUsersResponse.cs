using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.LoginUsers
{
    public class GetLoginUsersResponse
    {

        public GetLoginUsersResponse(string nombreUsuario, string apellidoPaterno, string apellidoMaterno, string correoUsuario, string nombreEntidad, string rutEntidad, int idPerfil, int idEntidad, string ultimaSession)

        {
            NombreUsuario = nombreUsuario;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            CorreoUsuario = correoUsuario;
            NombreEntidad = nombreEntidad;
            RutEntidad = rutEntidad;
            IdPerfil = idPerfil;           
            IdEntidad = idEntidad;
            UltimaSession = ultimaSession;
            
        }


        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("idPerfil")]
        public int IdPerfil { get; set; }       

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("ultimaSession")]
        public string UltimaSession { get; set; }       
       
    }
}
