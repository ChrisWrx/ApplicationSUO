using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.ListaPerfilUsuarioByIdRut
{
    public class GetListaPerfilUsuarioByIdRutResponse
    {
        public GetListaPerfilUsuarioByIdRutResponse(int idLogin, int idUsuario, string rutUsuario, string nombreUsuario, string apellidoPaterno, string apellidoMaterno, string correoUsuario, int idEntidad, string rutEntidad, string nombreEntidad, int idEstado, string descripcionEstado, string descripcionPerfil, string fechaRegistro, string fechaModificacion)
        {
            IdLogin = idLogin;
            IdUsuario = idUsuario;
            RutUsuario = rutUsuario;
            NombreUsuario = nombreUsuario;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            CorreoUsuario = correoUsuario;
            IdEntidad = idEntidad;
            RutEntidad = rutEntidad;
            NombreEntidad = nombreEntidad;
            IdEstado = idEstado;
            DescripcionEstado = descripcionEstado;
            DescripcionPerfil = descripcionPerfil;
            FechaRegistro = fechaRegistro;
            FechaModificacion = fechaModificacion;
        }

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
